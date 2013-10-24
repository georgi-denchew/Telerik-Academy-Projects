using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Forum.Models;
using System.Web.ModelBinding;

namespace Forum.Student
{
    public partial class Lecture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new AcademyDbContext();


        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                var context = new AcademyDbContext();
                var user = context.Users.FirstOrDefault(u => u.UserName == username);

                var registerPanel = this.FormViewCourse.FindControl("PanelRegisterForCourse") as Panel;
                int courseId = Convert.ToInt32(RouteData.Values["courseId"]);
                var course = context.Courses.FirstOrDefault(c => c.Id == courseId);

                if (course != null && !user.Courses.Contains(course) && course.FreePlaces > 0)
                {
                    (registerPanel.FindControl("ButtonRegisterForCourse") as Button).Visible = true;
                }
                else if (user.Courses.Contains(course))
                {
                    var label = new Label() { Text = "You are already registered for this course." };
                    registerPanel.Controls.Add(label);
                }
                else
                {
                    var label = new Label() { Text = "There are no free places for this course." };
                    registerPanel.Controls.Add(label);
                }

                var xd = this.GridViewLectures.Rows;
            }


        }


        public IQueryable<Forum.Models.Lecture> GridViewLectures_GetData([RouteData]int courseId)
        {
            return FormViewCourse_GetItem(courseId).Lectures.AsQueryable();
        }

        public Forum.Models.Course FormViewCourse_GetItem([RouteData]int courseId)
        {
            var context = new AcademyDbContext();
            return context.Courses.Find(courseId);
        }

        protected void ButtonRegisterForCourse_Click(object sender, EventArgs e)
        {
            string username = Context.User.Identity.Name;

            var context = new AcademyDbContext();
            var user = context.Users.FirstOrDefault(u => u.UserName == username);
            int courseId = Convert.ToInt32(RouteData.Values["courseId"]);
            var course = context.Courses.FirstOrDefault(c => c.Id == courseId);

            if (user != null && course != null && course.FreePlaces > 0)
            {
                user.Courses.Add(course);
                course.Students.Add(user);
                course.FreePlaces--;

                context.SaveChanges();
            }

            Response.Redirect(Request.RawUrl, false);
        }

        public string GetHomeworkLinks(int lectureId)
        {
            var context = new AcademyDbContext();
            string result = "";

            //get current user
            string username = User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.UserName == username);



            var lecture = context.Lectures.FirstOrDefault(x => x.Id == lectureId);

            if (lecture.HomeworkDueDate < DateTime.Now)
            {
                foreach (GridViewRow row in this.GridViewLectures.Rows)
                {
                    var datakey = Convert.ToInt32(GridViewLectures.DataKeys[row.RowIndex]["Id"]);
                    if (datakey == lectureId)
                    {
                        (row.FindControl("PanelUpload") as Panel).Visible = false;
                        break;
                    }
                }
            }

            if (user.Courses.Contains(lecture.Course))
            {
                var hw = lecture.Homeworks.FirstOrDefault(x => x.Student == user);
                if (hw != null)
                {
                    result += "<a href='../../" + hw.HomeworkPath.Remove(0, 2) + "'>Download</a><br/>";
                }

                if (lecture.HomeworkDueDate > DateTime.Now)
                {
                    result += "<a href='../Homeworks/" + lectureId + "'>Upload</a>";
                }
                else
                {
                    result += "<em>Expired</em>";
                }
            }

            return result;
        }
    }
}