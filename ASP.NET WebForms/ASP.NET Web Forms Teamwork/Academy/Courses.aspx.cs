using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Courses1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Forum.Models.Course> GridViewAnonymousCourses_GetData()
        {
            var context = new AcademyDbContext();
            return context.Courses;
        }
    }
}