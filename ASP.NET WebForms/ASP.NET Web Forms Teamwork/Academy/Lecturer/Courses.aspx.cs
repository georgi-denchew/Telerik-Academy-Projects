using Error_Handler_Control;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Courses : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack) 
            //{
            //    var context = new AcademyDbContext();
            //    var courses = context.Courses.ToList();
            //    this.GridViewCourses.DataSource = courses;
            //    this.GridViewCourses.DataBind();
            //}
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Course> GridViewCourses_GetData()
        {
            var context = new AcademyDbContext();
            return context.Courses.Include("Lecturer").OrderBy(c => c.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCourses_DeleteItem(int id)
        {

        }

        protected void LinkButtonCourseInsert_Click(object sender, EventArgs e)
        {
            string title = (this.GridViewCourses.FooterRow.FindControl("TextBoxCourseTitleInsert") as TextBox).Text;
            string description = (this.GridViewCourses.FooterRow.FindControl("TextBoxCourseDescriptionInsert") as TextBox).Text;
            string lecturer = (this.GridViewCourses.FooterRow.FindControl("DropDownListLecturersInsert") as DropDownList).SelectedValue;
            int freePlaces = int.Parse((this.GridViewCourses.FooterRow.FindControl("TextBoxFreePlacesInsert") as TextBox).Text);
            DateTime startDate = DateTime.Parse((this.GridViewCourses.FooterRow.FindControl("TextBoxStartDateInsert") as TextBox).Text);
            DateTime endDate = DateTime.Parse((this.GridViewCourses.FooterRow.FindControl("TextBoxEndDateInsert") as TextBox).Text);

            var context = new AcademyDbContext();

            var existingCourse = context.Courses.FirstOrDefault(c => c.Title == title);

            if (existingCourse != null)
            {
                throw new InvalidOperationException("Course already exists.");
            }

            var existingUser = context.Users.FirstOrDefault(x => x.Id == lecturer);

            if (existingUser == null)
            {
                throw new ArgumentException();
            }

            var courseToInsert = new Course()
            {
                Title = title,
                Description = description,
                Lecturer = existingUser,
                FreePlaces = freePlaces,
                StartDate = startDate,
                EndDate = endDate
            };

            context.Courses.Add(courseToInsert);
            context.SaveChanges();

            this.GridViewCourses.DataBind();

            ErrorSuccessNotifier.AddSuccessMessage("Course successfully added.");
        }

        protected void LinkButtonEmptyCourseInsert_Click(object sender, EventArgs e)
        {
            var table = (sender as LinkButton).Parent;
            string title = (table.FindControl("TextBoxEmptyCourseNameInsert") as TextBox).Text;
            string description = (table.FindControl("TextBoxEmptyCourseDescriptionInsert") as TextBox).Text;
            string lecturer = (table.FindControl("DropDownListEmptyLecturerInsert") as DropDownList).SelectedValue;
            int freePlaces = int.Parse((table.FindControl("TextBoxEmptyCourseFreePlacesInsert") as TextBox).Text);
            DateTime startDate = DateTime.Parse((table.FindControl("TextBoxEmptyCourseStartDateInsert") as TextBox).Text);
            DateTime endDate = DateTime.Parse((table.FindControl("TextBoxEmptyCourseEndDateInsert") as TextBox).Text);

            var context = new AcademyDbContext();

            var existingCourse = context.Courses.FirstOrDefault(c => c.Title == title);

            if (existingCourse != null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Course successfully added.");
                //throw new InvalidOperationException("Course already exists.");
            }

            var existingUser = context.Users.FirstOrDefault(x => x.Id == lecturer);

            if (existingUser == null)
            {
                throw new ArgumentException();
            }

            var courseToInsert = new Course()
            {
                Title = title,
                Description = description,
                Lecturer = existingUser,
                FreePlaces = freePlaces,
                StartDate = startDate,
                EndDate = endDate
            };

            context.Courses.Add(courseToInsert);
            context.SaveChanges();

            this.GridViewCourses.DataBind();

            ErrorSuccessNotifier.AddSuccessMessage("Course successfully added.");
        }



        protected void GridViewCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string courseTitle = ((sender as GridView).Rows[e.RowIndex].FindControl("TextBoxCourseTitleEdit") as TextBox).Text;
            string courseDescription = ((sender as GridView).Rows[e.RowIndex].FindControl("TextBoxCourseDescriptionEdit") as TextBox).Text;
            string courseLecturerId = ((sender as GridView).Rows[e.RowIndex].FindControl("DropDownListLecturerEdit") as DropDownList).SelectedValue;
            int courseFreePlaces = int.Parse(((sender as GridView).Rows[e.RowIndex].FindControl("TextBoxFreePlacesEdit") as TextBox).Text.ToString());
            DateTime startDate = DateTime.Parse(((sender as GridView).Rows[e.RowIndex].FindControl("TextBoxStartDateEdit") as TextBox).Text.ToString());
            DateTime endDate = DateTime.Parse(((sender as GridView).Rows[e.RowIndex].FindControl("TextBoxEndDateEdit") as TextBox).Text.ToString());

            int id = (int)e.Keys["Id"];

            var context = new AcademyDbContext();

            var existingCourse = context.Courses.FirstOrDefault(x => x.Id == id);

            if (existingCourse == null)
            {
                throw new InvalidOperationException("Course does not exist");
            }

            var existingUser = context.Users.FirstOrDefault(x => x.Id == courseLecturerId);

            if (existingUser == null)
            {
                throw new ArgumentException("Lecturer does not exist");
            }

            existingCourse.Title = courseTitle;
            existingCourse.Description = courseDescription;
            existingCourse.Lecturer = existingUser;
            existingCourse.FreePlaces = courseFreePlaces;
            existingCourse.StartDate = startDate;
            existingCourse.EndDate = endDate;

            context.SaveChanges();
            //ErrorSuccessNotifier.AddInfoMessage("Course successfully edited.");
            e.Cancel = true;
            (sender as GridView).EditIndex = -1;
        }

        protected void GridViewCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridViewCourses.EditIndex = e.NewEditIndex;
            var id = int.Parse(this.GridViewCourses.DataKeys[e.NewEditIndex].Value.ToString());
            Session["course-id"] = id;
            this.GridViewCourses.SelectMethod = "GridViewCourses_GetData";// your gridview binding function
        }

        protected void GridViewCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)e.Keys["Id"];
            var context = new AcademyDbContext();
            var existingCourse = context.Courses.FirstOrDefault(c => c.Id == id);
            var lectures = existingCourse.Lectures.ToList();
            foreach (var lecture in lectures)
            {
                context.Homeworks.RemoveRange(lecture.Homeworks);
                context.Lectures.Remove(lecture);
            }

            context.SaveChanges();

            context.Courses.Remove(existingCourse);
            context.SaveChanges();

            e.Cancel = true;
            (sender as GridView).DataBind();

            ErrorSuccessNotifier.AddInfoMessage("Course successfully deleted.");
        }


        protected void GridViewCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = this.GridViewCourses.SelectedDataKey.Value.ToString();
            Response.RedirectToRoute("LectureInCourseRoute", new { courseId = id });
        }

        public IQueryable<ApplicationUser> DropDownListLecturer_GetData()
        {

            var context = new AcademyDbContext();
            return context.Users.Where(x => x.Roles.Any(r => r.Role.Name == "Lecturer"));

        }

        protected void GridViewCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("DropDownListLecturerEdit");
                    //bind dropdownlist

                    var context = new AcademyDbContext();

                    var id = int.Parse(Session["course-id"].ToString());
                    var lectureId = context.Courses.FirstOrDefault(x => x.Id == id).Lecturer.Id;
                    ddList.SelectedValue = lectureId;
                }
            }

        }



    }
}