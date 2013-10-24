using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Forum.Models;
using System.Web.ModelBinding;

namespace Forum.Lecturer
{
    public partial class Homeworks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Forum.Models.Homework> GridViewHomeworks_GetData([ViewState("courseId")]string courseId = null)
        {
            var context = new AcademyDbContext();
            if (courseId != null)
            {
                var Id = Convert.ToInt32(courseId);
                return context.Homeworks
                    .Include(h => h.Lecture)
                    .Include(h => h.Student)
                    .Where(x => x.Lecture.Course.Id == Id);
            }

            int selectedCourseId=int.Parse(this.DropDownListCourses.SelectedValue);
            return context.Homeworks
                    .Include(h => h.Lecture)
                    .Include(h => h.Student)
                    .Where(x => x.Lecture.Course.Id == selectedCourseId);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewHomeworks_UpdateItem(int id)
        {
            Forum.Models.Homework item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewHomeworks_DeleteItem(int id)
        {

        }

        public IQueryable<Course> DropDownListCourses_GetData([ViewState("courseId")]string courseId = null)
        {
            var context = new AcademyDbContext();
            return context.Courses;
        }

        protected void DropDownListCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new AcademyDbContext();

            var index = this.DropDownListCourses.SelectedValue;
            ViewState["courseId"] = index;
            this.GridViewHomeworks.DataBind();
            this.DropDownListCourses.SelectedValue = index;
        }
    }
}