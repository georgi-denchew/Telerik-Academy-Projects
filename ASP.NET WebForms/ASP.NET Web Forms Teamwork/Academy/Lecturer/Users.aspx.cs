using Error_Handler_Control;
using Forum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<ApplicationUser> GridViewUsers_GetData()
        {
            var context = new AcademyDbContext();
            var userId = Context.User.Identity.GetUserId();

            return context.Users
                .Include(u => u.Courses)
                .Include(u => u.Roles)
                .Where(u => u.Id != userId);
        }

        public void GridViewUsers_UpdateItem(string id)
        {
            var context = new AcademyDbContext();
            Forum.Models.ApplicationUser item = context.Users.Find(id);

            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            var editIndex = this.GridViewUsers.EditIndex;

            bool isLecturer = (this.GridViewUsers.Rows[editIndex].FindControl("CheckBoxIsLecturer") as CheckBox).Checked;
            if (isLecturer)
            {
                var lecturerRole = context.Roles.First(r => r.Name == "Lecturer");
                item.Roles.Clear();
                item.Roles.Add(new UserRole() { Role = lecturerRole });
            }
            else
            {
                item.Roles.Clear();
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("User edited successfully.");
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("There was an error editing the user. Please try again.");
            }
        }

        public IQueryable<Role> DropDownListRole_GetData()
        {
            var context = new AcademyDbContext();
            return context.Roles;
        }
    }
}