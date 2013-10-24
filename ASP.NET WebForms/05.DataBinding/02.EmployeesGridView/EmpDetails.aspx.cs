using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.EmployeesGridView
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Id"] == null)
            {
                Response.Redirect("EmployeesPage.aspx");
            }

            int id = int.Parse(Request.Params["Id"]);

            NorthwindEntities context = new NorthwindEntities();
            List<Employee> employees = context.Employees.Where(x => x.EmployeeID == id).ToList();

            this.DetailsViewEmployee.DataSource = employees;
            this.DataBind();
        }
    }
}