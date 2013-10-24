using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.FormView
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

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)this.GridViewEmployees.SelectedDataKey.Value;

            NorthwindEntities context = new NorthwindEntities();
            List<Employee> employees = context.Employees.Where(x => x.EmployeeID == id).ToList();

            this.FormViewEmployeeDetails.DataSource = employees;

            this.FormViewEmployeeDetails.DataBind();
        }
    }
}