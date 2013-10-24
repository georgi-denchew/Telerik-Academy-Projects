using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Forum.Models;
using System.Web.ModelBinding;
using Error_Handler_Control;

namespace Forum
{
    public partial class Lecture : System.Web.UI.Page
    {
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

        public void GridViewLectures_UpdateItem(int id)
        {
            var context = new AcademyDbContext();
            Forum.Models.Lecture item = context.Lectures.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("Lecture updated successfully.");
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("There was an error updating the lecture. Please try again.");
            }
        }

        public void GridViewLectures_DeleteItem(int id)
        {
            var context = new AcademyDbContext();
            Forum.Models.Lecture item = context.Lectures.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                ErrorSuccessNotifier.AddErrorMessage("The lecture was not found.");
                return;
            }

            try
            {
                context.Lectures.Remove(item);
                context.SaveChanges();

                this.GridViewLectures.SelectMethod = "GridViewLectures_GetData";
                this.GridViewLectures.DataBind();
                ErrorSuccessNotifier.AddInfoMessage("Lecture deleted successfully.");

            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        protected void ButtonInsertLecture_Click(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt32(this.RouteData.Values["courseId"]);
            string title = (this.GridViewLectures.FooterRow.FindControl("TextBoxInsertTitle") as TextBox).Text;
            string location = (this.GridViewLectures.FooterRow.FindControl("TextBoxInsertLocation") as TextBox).Text;
            DateTime homeworkDueDate = DateTime.Parse((this.GridViewLectures.FooterRow.FindControl("TextBoxInsertHomeworkDue") as TextBox).Text);

            var context = new AcademyDbContext();
            var course = context.Courses.Find(courseId);
            var lecture = new Forum.Models.Lecture()
            {
                Title = title,
                Location = location,
                HomeworkDueDate = homeworkDueDate
            };

            context.Lectures.Add(lecture);
            try
            {
                context.SaveChanges();
                lecture.Course = course;
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Lecture created successfully.");
            }
            catch (Exception ex) 
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }

            this.GridViewLectures.SelectMethod = "GridViewLectures_GetData";
            this.GridViewLectures.DataBind();
        }

        protected void LinkButtonEmptyLectureInsert_Click(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt32(this.RouteData.Values["courseId"]);
            var table = (sender as LinkButton).Parent;
            string title = (table.FindControl("TextBoxEmptyLectureTitleInsert") as TextBox).Text;
            string description = (table.FindControl("TextBoxEmptyLectureDescriptionInsert") as TextBox).Text;
            string location = (table.FindControl("TextBoxEmptyLectureLocationInsert") as TextBox).Text;
            DateTime homeworkDueDate = DateTime.Parse((table.FindControl("TextBoxEmptyHomeworkDue") as TextBox).Text);

            var context = new AcademyDbContext();
            var course = context.Courses.Find(courseId);
            var lecture = new Forum.Models.Lecture()
            {
                Title = title,
                Location = location,
                HomeworkDueDate = homeworkDueDate
            };

            context.Lectures.Add(lecture);
            try
            {
                context.SaveChanges();
                lecture.Course = course;
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Lecture created successfully.");
            }
            catch (Exception ex) 
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }

            this.GridViewLectures.SelectMethod = "GridViewLectures_GetData";
            this.GridViewLectures.DataBind();
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

        public IQueryable<Resource> DropDownListResourceType_GetData()
        {
            var context = new AcademyDbContext();
            return context.Resources;
        }

        protected void LinkButtonAddResource_Click(object sender, EventArgs e)
        {

        }
    }
}