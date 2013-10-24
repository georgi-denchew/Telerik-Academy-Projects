using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.ListView
{
    public partial class EmployeesListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities context=  new NorthwindEntities();

            List<Models.Employee> employees =
                (from emp in context.Employees
                select new Models.Employee
                {
                    EmployeeID = emp.EmployeeID,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Address = emp.Address,
                    BirthDate = emp.BirthDate,
                    City = emp.City,
                    Country = emp.Country,
                    HireDate = emp.HireDate,
                    HomePhone = emp.HomePhone,
                    PostalCode = emp.PostalCode,
                    Region = emp.Region,
                    Title = emp.Title,
                    TitleOfCourtesy = emp.TitleOfCourtesy
                }).ToList();

            this.ListViewEmployees.DataSource = employees;
            this.ListViewEmployees.DataBind();
        }
    }
}