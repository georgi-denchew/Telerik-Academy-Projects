using System;
using System.Linq;

// I have put all the tasks in a single project to ease their examination(testing)
namespace NorthwindTasks
{
    class Tasks
    {
        static void Main(string[] args)
        {
            // TASK 01 --> See NorthwindEntities.admx

            NorthwindEntities nwEntities = new NorthwindEntities();

            //TASK 02 add customer example
            DAO.InsertCustomer(nwEntities, "aaaaa", "company name", "conatct name", "contact title",
                "address", "city", "region", "postalCode", "counrty",
               "phone", "fax");

            // TASK 02 modify customer example
            DAO.ModifyCustomer(nwEntities, "aaaaa", "Telerik", "Pesho", "Title",
                "18309 First str.", "Silver Spring", "MD", "28079",
                "USA", "0000123", "+123414");

            // TASK 02 delete customer example
            DAO.DeleteCustomer(nwEntities, "aaaaa");

            Console.WriteLine("TASK 03");
            Console.WriteLine();
            
            // TASK 03 get customers by order year and shipping country
            DAO.GetCustomersByOrderAndCountry(nwEntities, 1997, "Germany");
            Console.WriteLine();

            Console.WriteLine("TASK 04");
            Console.WriteLine();
            // TASK 04 Implement previous by using native SQL query and executing it through the DbContext.
            var customersDbContext = DAO.SelectCustomersByOrderAndCountryDBContext(nwEntities, 1997, "Germany").ToList();
            DAO.PrintCustomers(customersDbContext);
            Console.WriteLine();

            Console.WriteLine("TASK 05");
            Console.WriteLine();
            //TASK 05 Write a method that finds all the sales by specified region and period (start / end dates).
            DateTime startDate = new DateTime(1997, 01, 01);
            DateTime endDate = new DateTime(1997, 12, 31);
            string region = "RJ";
            DAO.GetSalesByRegionAndPeriod(nwEntities, region, startDate, endDate);

            //TASK 06 --> Look in the Solution Explorer

            Console.WriteLine();
            //TASK 07 Performing concurrent changes on same records with two data contexts
            NorthwindEntities firstContext = new NorthwindEntities();
            NorthwindEntities secondContext = new NorthwindEntities();

            DAO.InsertCustomer(firstContext, "aaa", "company name", "conatct name", "contact title",
                "address", "city", "region", "postalCode", "counrty",
               "phone", "fax");

            DAO.ModifyCustomer(secondContext, "aaa", "Telerik", "Pesho", "Title",
                "18309 First str.", "Silver Spring", "MD", "28079",
                "USA", "0000123", "+123414");

            DAO.ModifyCustomer(firstContext, "aaa", "Second modification Telerik", "Pesho", "Title",
                "18309 First str.", "Silver Spring", "MD", "28079",
                "USA", "0000123", "+123414");

            DAO.DeleteCustomer(secondContext, "aaa");

            //Conclusion: The two dataContexts do not interfere in each other's work => the first one WINS :D
            Console.WriteLine();

            Console.WriteLine("TASK 08");
            Console.WriteLine();
            //TASK 08 employees accessing their territories
            var employee = nwEntities.Employees.Find(1);
            Console.Write("Territories for the employee {0}: ",
                employee.FirstName.Trim() + " " + employee.LastName.Trim());
            foreach (var territory in employee.EntityTerritories)
            {
                Console.Write("{0}, ", territory.TerritoryDescription.Trim());
            }
            Console.WriteLine();
            Console.WriteLine();
            //TASK 09 Method for placing orders with transaction

            Order firstOrder = new Order();

            firstOrder.CustomerID = "ALFKI";
            firstOrder.EmployeeID = 1;
            firstOrder.OrderDate = DateTime.Now;
            firstOrder.RequiredDate = DateTime.Now;
            firstOrder.ShippedDate = DateTime.Now;
            firstOrder.ShipVia = 2;
            firstOrder.Freight = 100;
            firstOrder.ShipName = "shipName";
            firstOrder.ShipAddress = "1234 first str.";
            firstOrder.ShipCity = "berlin";
            firstOrder.ShipRegion = "nj";
            firstOrder.ShipPostalCode = "123";
            firstOrder.ShipCountry = "germany";

            Order secondOrder = new Order();
            secondOrder.CustomerID = "ALFKI";
            secondOrder.EmployeeID = 2;
            secondOrder.OrderDate = DateTime.Now;
            secondOrder.RequiredDate = DateTime.Now;
            secondOrder.ShippedDate = DateTime.Now;
            secondOrder.ShipVia = 3;
            secondOrder.Freight = 1000;
            secondOrder.ShipName = "shipName";
            secondOrder.ShipAddress = "56 erste Strasse.";
            secondOrder.ShipCity = "berlin";
            secondOrder.ShipRegion = "nj";
            secondOrder.ShipPostalCode = "123";
            secondOrder.ShipCountry = "germany";

            Order[] allOrders = new Order[] { firstOrder, secondOrder };

            DAO.InsertOrders(nwEntities, allOrders);

            Console.WriteLine("TASK 10");
            Console.WriteLine();
            //// TASK 10 Stored Procedure  !!!NOTE --> a private method in DAO creates the stored procedure
            string supplierName = "Bigfoot Breweries";
            DateTime startOrderDate = new DateTime(1996, 01, 01);
            DateTime endOrderDate = new DateTime(1998, 12, 31);

            var supplier = DAO.GetTotalIncome(nwEntities, supplierName, startOrderDate, endOrderDate);
            Console.WriteLine(supplier);
        }
    }
}
