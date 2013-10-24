using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.EmployeesGridView
{
    public partial class EmployeesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Employee> GridViewEmployees_GetData()
        {
            NorthwindEntities context = new NorthwindEntities();
            return context.Employees;
        }
    }
}