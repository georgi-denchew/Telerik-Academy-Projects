using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.Repeater
{
    public partial class EmployeesRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities context = new NorthwindEntities();
            List<Employee> employees = context.Employees.ToList();

            this.RepeaterEmployees.DataSource = employees;
            this.RepeaterEmployees.DataBind();
        }
    }
}