using Error_Handler_Control;
using Forum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Forum.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        private const string MainPath = "~/img/UserAvatars/";
        private const string DefaultImagePath = "~/img/UserAvatars/default.png";
        private const string GifImageFormat = "image/gif";
        private const string PngImageFormat = "image/png";
        private const string JpegImageFormat = "image/jpeg";

        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determine the sections to render
                ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
                if (manager.HasLocalLogin(User.Identity.GetUserId()))
                {
                    changePasswordHolder.Visible = true;
                }
                else
                {
                    setPassword.Visible = true;
                    changePasswordHolder.Visible = false;
                }
                CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }

            var username = Context.User.Identity.Name;
            var context = new AcademyDbContext();
            var user = context.Users.FirstOrDefault(u => u.UserName == username);
            if (user != null)
            {
                var avatarPath = user.AvatarPath;
                var avatarImage = this.PlaceHolderChangeAvatar.FindControl("ImageUserAvatar") as Image;
                avatarImage.ImageUrl = avatarPath;
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                IPasswordManager manager = new IdentityManager(new IdentityStore()).Passwords;
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserName(), CurrentPassword.Text, NewPassword.Text);
                if (result.Success)
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
                IdentityResult result = manager.AddLocalLogin(User.Identity.GetUserId(), User.Identity.GetUserName(), password.Text);
                if (result.Success)
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        public IEnumerable<IUserLogin> GetLogins()
        {
            ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
            var accounts = manager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1;
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
            var result = manager.RemoveLogin(User.Identity.GetUserId(), loginProvider, providerKey);
            var msg = result.Success
                ? "?m=RemoveLoginSuccess"
                : String.Empty;
            Response.Redirect("~/Account/Manage" + msg);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void ChangeAvatar_Click(object sender, EventArgs e)
        {
            var context = new AcademyDbContext();
            string username = Context.User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.UserName == username);

            if (user != null)
            {
                string fileName = string.Empty;

                var fileUpload = this.FileUploadAvatar;
                if (fileUpload.HasFile &&
                    (fileUpload.PostedFile.ContentType == PngImageFormat ||
                    fileUpload.PostedFile.ContentType == JpegImageFormat ||
                    fileUpload.PostedFile.ContentType == GifImageFormat))
                {
                    fileName = username.Replace("<", string.Empty).Replace(">", string.Empty) + GetAvatarExtension(FileUploadAvatar.PostedFile.FileName);
                    fileUpload.SaveAs(Server.MapPath(MainPath) + fileName);

                    user.AvatarPath = MainPath + fileName;
                    context.SaveChanges();

                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    ErrorSuccessNotifier.AddSuccessMessage("Avatar changed successfully.");
                    Response.Redirect(Request.RawUrl, false);
                }
                else
                {
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    ErrorSuccessNotifier.AddErrorMessage("The uploaded avatar exceeds 100KB or is in a wrong format.");
                    Response.Redirect(Request.RawUrl, false);
                    return;
                }
            }
        }

        private string GetAvatarExtension(string fileName)
        {
            var dotIndex = fileName.LastIndexOf('.');
            var extension = fileName.Substring(dotIndex);

            return extension;
        }

        protected void ChangeEmail_Click(object sender, EventArgs e)
        {
            var userId = Context.User.Identity.GetUserId();
            var context = new AcademyDbContext();
            var user = context.Users.Find(userId);
            user.Email = this.TextBoxNewEmail.Text;

            context.SaveChanges();
            Response.Redirect(Request.RawUrl, false);
        }

        public IQueryable<Forum.Models.ApplicationUser> ListViewUserInfo_GetData()
        {
            var context = new AcademyDbContext();
            string userId = Context.User.Identity.GetUserId();
            var user = context.Users.Find(userId);

            if (user != null)
            {
                return new List<ApplicationUser> { user }.AsQueryable();
            }

            return null;
        }
    }
}