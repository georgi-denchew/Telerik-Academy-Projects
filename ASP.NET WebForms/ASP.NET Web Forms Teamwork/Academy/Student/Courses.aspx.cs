using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.Student
{
    public partial class Courses : System.Web.UI.Page
    {
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Course> GridViewStudentCourses_GetData()
        {
            var context = new AcademyDbContext();
            return context.Courses.Include("Lecturer").OrderBy(c => c.Id);
        }
        
        protected void GridViewStudentCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = this.GridViewStudentCourses.SelectedDataKey.Value.ToString();
            Response.RedirectToRoute("StudentInCourseRoute", new { courseId = id });
        }


        protected void GridViewStudentCourses_RowDataBound(object sender, GridViewRowEventArgs e)
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