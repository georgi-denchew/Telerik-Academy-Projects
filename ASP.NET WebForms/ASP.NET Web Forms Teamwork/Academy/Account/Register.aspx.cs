using Error_Handler_Control;
using Forum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Forum.Account
{
    public partial class Register : Page
    {
        private const string MainPath = "~/img/UserAvatars/";
        private const string DefaultImagePath = "~/img/UserAvatars/default.png";
        private const string GifImageFormat = "image/gif";
        private const string PngImageFormat = "image/png";
        private const string JpegImageFormat = "image/jpeg";

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;

            var manager = new AuthenticationIdentityManager(new IdentityStore(new AcademyDbContext()));
            ApplicationUser u = new ApplicationUser(userName)
            {
                UserName = userName,
                FirstName = this.TextBoxFirstName.Text,
                LastName = this.TextBoxLastName.Text,
                Email = this.TextBoxEmail.Text,
                JoinDate = DateTime.Now,

            };
            var context = new AcademyDbContext();

            string fileName = string.Empty;

            var fileUpload = this.FileUploadAvatar;
            if (fileUpload.HasFile)
            {
                if (fileUpload.PostedFile.ContentLength < 102400 &&
                (fileUpload.PostedFile.ContentType == PngImageFormat ||
                fileUpload.PostedFile.ContentType == JpegImageFormat ||
                fileUpload.PostedFile.ContentType == GifImageFormat))
                {
                    fileName = userName.Replace("<", string.Empty).Replace(">", string.Empty) + GetAvatarExtension(FileUploadAvatar.PostedFile.FileName);
                    fileUpload.SaveAs(Server.MapPath(MainPath) + fileName);
                    u.AvatarPath = MainPath + fileName;
                }
                else
                {
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    ErrorSuccessNotifier.AddErrorMessage("The uploaded avatar exceeds 100KB or is in a wrong format.");
                    Response.Redirect(Request.RawUrl, false);
                    return;
                }
            }
            else
            {
                u.AvatarPath = DefaultImagePath;
            }

            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success)
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                ErrorSuccessNotifier.AddSuccessMessage("Registration completed successfully.");
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage(result.Errors.FirstOrDefault());
            }

        }

        private string GetAvatarExtension(string fileName)
        {
            var dotIndex = fileName.LastIndexOf('.');
            var extension = fileName.Substring(dotIndex);

            return extension;
        }
    }
}