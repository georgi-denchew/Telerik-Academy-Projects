using ForumDb.Data;
using ForumDb.Models;
using ForumDb.WebAPI.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;

namespace ForumDb.WebAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private IDbContextFactory<DbContext> contextFactory;
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_.";
        private const string ValidNicknameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_. -";
        private const int Sha1Length = 40;
        private const int SessionKeyLength = 50;
        private const string SessionKeyChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly Random rand = new Random();

        public UsersController()
        {
            this.contextFactory = new ForumDbContextFactory();
        }

        public UsersController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        //     {  "username": "DonchoMinkov",
        //"nickname": "Doncho Minkov",
        //"authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" }

        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {

                    var context = new ForumContext();

                    using (context)
                    {
                        this.ValidateUsername(model.Username);
                        this.ValidateNickname(model.Nickname);
                        this.ValidateAuthCode(model.AuthCode);


                        var usernameToLower = model.Username.ToLower();
                        var nickanmeToLower = model.Nickname.ToLower();

                        var user = context.Users.FirstOrDefault(usr => usr.Username == usernameToLower ||
                            usr.Nickname.ToLower() == nickanmeToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("User exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            Nickname = model.Nickname,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            Nickname = user.Nickname,
                            SessionKey = user.SessionKey
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);

                        return response;
                    }
                });

            return responseMsg;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);

            while(skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }

            return skeyBuilder.ToString();
        }

        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();

                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);


                    var usernameToLower = model.Username.ToLower();

                    var user = context.Users.FirstOrDefault(usr => usr.Username == usernameToLower &&
                        usr.AuthCode == model.AuthCode);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }

                    if (user.SessionKey == null)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();
                    }

                    var loggedModel = new LoggedUserModel()
                    {
                        Nickname = user.Nickname,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);

                    return response;
                }
            });

            return responseMsg;
        }

        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == model.SessionKey);

                if (user == null)
                {
                    throw new InvalidCastException("Invalid user");
                }

                user.SessionKey = null;
                context.SaveChanges();

                var response = this.Request.CreateResponse(HttpStatusCode.OK);

                return response;
            });

            return responseMsg;
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateNickname(string nickname)
        {
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }

            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long", MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long", MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException("Username must contain only Latin letters, digits .,_");
            }
        }

        
    }
}
