using Error_Handler_Control;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.Student
{
    public partial class Homework : System.Web.UI.Page
    {
        private const string DefaultHomeworksPath = "~/Homeworks/";
        private const string KeyLectureActive = "lectureActive";
        private const string KeyLectureAndUserExist = "lectureAndUserExist";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session[KeyLectureActive] = false;
            Session[KeyLectureAndUserExist] = false;

            string username = Context.User.Identity.Name;
            int lectureId = Convert.ToInt32(RouteData.Values["lectureId"]);
            var context = new AcademyDbContext();
            var user = context.Users.FirstOrDefault(u => u.UserName == username);
            var lecture = context.Lectures.Find(lectureId);

            if (user != null && lecture != null)
            {
                if (lecture.HomeworkDueDate < DateTime.Now || !user.Courses.Contains(lecture.Course))
                {
                    Response.Clear();
                    ErrorSuccessNotifier.ShowAfterRedirect = false;
                    ErrorSuccessNotifier.AddErrorMessage("You do not have the right to upload a homework for this lecture.");
                }
                else
                {
                    Session[KeyLectureAndUserExist] = true;
                    Session[KeyLectureActive] = true;
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("The lecture does not exist or there is no currently logged in user.");
            }
        }

        public Forum.Models.Lecture FormViewUploadHomework_GetItem([RouteData]int lectureId)
        {
            if (Convert.ToBoolean(Session[KeyLectureActive]) && Convert.ToBoolean(Session[KeyLectureAndUserExist]))
            {
                var context = new AcademyDbContext();
                return context.Lectures.Find(lectureId);
            }

            this.PanelWrapper.Visible = false;
            return null;
        }

        protected void ButtonUploadHomework_Click(object sender, EventArgs e)
        {
            var context = new AcademyDbContext();
            int lectureId = Convert.ToInt32(RouteData.Values["lectureId"]);
            var lecture = context.Lectures.Find(lectureId);
            string username = Context.User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.UserName == username);
            if (lecture == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("The lecture does not exist.");
            }

            if (user == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("The user does not exist.");
            }

            var fileUpload = this.FileUploadHomework;

            ErrorSuccessNotifier.ShowAfterRedirect = true;
            if (fileUpload.HasFile)
            {
                if (fileUpload.PostedFile.ContentLength <= 16777216)
                {
                    if (fileUpload.PostedFile.FileName.EndsWith(".zip") || fileUpload.PostedFile.FileName.EndsWith(".rar"))
                    {
                        if (!Directory.Exists(Server.MapPath(DefaultHomeworksPath + lectureId)))
                        {
                            Directory.CreateDirectory(Server.MapPath(DefaultHomeworksPath + lectureId));
                        }

                        string userForFileName = username.Replace("<", string.Empty).Replace(">", string.Empty);

                        string fileName = string.Format(
                            "HW_{0}_{1}{2}", userForFileName,
                            Regex.Replace(lecture.Title, @"[\W]", "_"),
                            GetFileExtension(fileUpload.PostedFile.FileName));
                        string homeworkPath = DefaultHomeworksPath + lectureId + "/" + fileName;
                        fileUpload.SaveAs(Server.MapPath(homeworkPath));

                        var existingHomework = context.Homeworks.FirstOrDefault(h => h.HomeworkPath == homeworkPath);
                        if (existingHomework == null)
                        {
                            var newHomework = context.Homeworks.Add(new Forum.Models.Homework()
                            {
                                Student = user,
                                StudentId = user.Id,
                                Lecture = lecture,
                                LectureId = lecture.Id,
                                HomeworkPath = homeworkPath,
                                SubmissionTime = DateTime.Now
                            });
                        }
                        else
                        {
                            existingHomework.SubmissionTime = DateTime.Now;
                        }

                        try
                        {
                            context.SaveChanges();
                        }
                        catch (Exception)
                        {
                            ErrorSuccessNotifier.AddErrorMessage(
                                "There was a problem uploading the homework. Please contact the lecturer for this course.");
                            Response.Redirect(Request.RawUrl, false);
                            return;
                        }

                        ErrorSuccessNotifier.AddSuccessMessage("Homework uploaded successfully.");
                        Response.Redirect(string.Format("~/Student/Courses/{0}", lecture.Course.Id), false);
                    }
                    else
                    {
                        ErrorSuccessNotifier.AddErrorMessage("The file is in a wrong format. Allowed formats: .zip, .rar.");
                        Response.Redirect(Request.RawUrl, false);
                    }
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("The file size exceeds the limit of 16 MB.");
                    Response.Redirect(Request.RawUrl, false);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("There is no file to upload.");
                Response.Redirect(Request.RawUrl, false);
            }
        }

        private string GetFileExtension(string fileName)
        {
            var dotIndex = fileName.LastIndexOf('.');
            var extension = fileName.Substring(dotIndex);

            return extension;
        }
    }
}