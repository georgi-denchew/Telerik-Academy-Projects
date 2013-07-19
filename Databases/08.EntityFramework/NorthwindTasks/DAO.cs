using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Transactions;
using System.Data.SqlClient;

namespace NorthwindTasks
{
    public class DAO
    {
        public static void DeleteCustomer(NorthwindEntities nwEntities, string customerID)
        {
            Customer customer = GetCustomerByID(nwEntities, customerID);
            nwEntities.Customers.Remove(customer);
            nwEntities.SaveChanges();
        }

        public static void ModifyCustomer(NorthwindEntities nwEntities, string customerID,
            string companyName, string contactName, string contactTitle,
            string address, string city, string region, string postalCode,
            string country, string phone, string fax)
        {

            Customer customer = GetCustomerByID(nwEntities, customerID);

            customer.CompanyName = companyName;
            customer.ContactName = contactName;
            customer.ContactTitle = contactTitle;
            customer.Address = address;
            customer.City = city;
            customer.Region = region;
            customer.PostalCode = postalCode;
            customer.Country = country;
            customer.Phone = phone;
            customer.Fax = fax;

            nwEntities.SaveChanges();
        }

        private static Customer GetCustomerByID(NorthwindEntities nwEntities, string customerID)
        {

            Customer customer = nwEntities.Customers
                .FirstOrDefault(c => c.CustomerID == customerID);
            return customer;
        }

        /// <summary>
        /// Inserts a new customer in the Customers table of the Northwind databse.
        /// </summary>>
        public static void InsertCustomer(NorthwindEntities nwEntities, string customerID,
            string companyName, string contactName, string contactTitle,
            string address, string city, string region, string postalCode,
            string country, string phone, string fax)
        {

            Customer newCustomer = new Customer()
            {
                CustomerID = customerID,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            nwEntities.Customers.Add(newCustomer);
            nwEntities.SaveChanges();
        }

        public static void GetSalesByRegionAndPeriod(NorthwindEntities nwEntities, string region, DateTime startDate, DateTime endDate)
        {

            var sales = nwEntities.Orders.Where(
                o => o.ShipRegion == region &&
                o.OrderDate >= startDate &&
                o.OrderDate <= endDate).Select(o => new
                {
                    CompanyName = o.Customer.CompanyName,
                    Region = o.ShipRegion,
                    OrderDate = o.OrderDate
                });

            Console.WriteLine("Sales Count: {0}", sales.Count());
            foreach (var sale in sales)
            {
                Console.WriteLine("Company Name: {0}, Ship Region: {1}; Order Date: {2};",
                    sale.CompanyName, sale.Region, sale.OrderDate);
            }
        }

        public static void PrintCustomers(List<CustomerOrderAndCountry> customersDbContext)
        {
            Console.WriteLine("Customers count: {0}", customersDbContext.Count);

            foreach (var customer in customersDbContext)
            {
                Console.WriteLine(customer);
            }
        }

        public static void GetCustomersByOrderAndCountry(NorthwindEntities nwEntities, int year, string country)
        {
            var customers = nwEntities.Orders.Where(o => o.OrderDate.Value.Year == year
                    && o.ShipCountry == country).GroupBy(o => o.Customer.CompanyName);

            PrintCustomers(customers);
        }

        public static void PrintCustomers(IQueryable<IGrouping<string, Order>> customers)
        {
            Console.WriteLine("Customers count: {0}", customers.Count());
            foreach (var customer in customers)
            {
                Console.WriteLine("Company Name: {0}", customer.Key);
            }
        }

        public static IEnumerable<CustomerOrderAndCountry> SelectCustomersByOrderAndCountryDBContext(
            NorthwindEntities nwEntities, int orderDate, string country)
        {

            string query = "SELECT c.CompanyName " +
                " FROM Customers c JOIN Orders o" +
                " on o.CustomerID = c.CustomerID" +
                " AND FORMAT(o.OrderDate, 'yyyy') = {0}" +
                " AND o.ShipCountry = {1}" +
                " GROUP BY CompanyName";
            object[] parameters = { orderDate, country };
            var customers = nwEntities.Database.SqlQuery<CustomerOrderAndCountry>(query, parameters);
            return customers;
        }

        internal static void InsertOrders(NorthwindEntities nwEntities, Order[] allOrders)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                foreach (var order in allOrders)
                {
                    nwEntities.Orders.Add(order);
                    nwEntities.SaveChanges();
                }
            }
        }

        internal static SupplierNameAndTotalPrice GetTotalIncome(
            NorthwindEntities nwEntities, string supplierName, DateTime startDate, DateTime endDate)
        {
            GenerateStoredProcedure(nwEntities);
            var result = nwEntities.Database.SqlQuery<SupplierNameAndTotalPrice>(
                "exec usp_GetSupplierByNameAndPeriod @supplierName, @startDate, @endDate",
               new SqlParameter("supplierName", supplierName),
               new SqlParameter("startDate", startDate),
               new SqlParameter("endDate", endDate));

            return result.First();
        }

        public static void GenerateStoredProcedure(NorthwindEntities nwEntities)
        {
            string check =
                "IF EXISTS (SELECT * FROM sys.objects WHERE type='P' and name ='usp_GetSupplierByNameAndPeriod') " +
                " DROP PROCEDURE  usp_GetSupplierByNameAndPeriod";
            string query = " CREATE PROCEDURE usp_GetSupplierByNameAndPeriod" +
            " (@supplierName nvarchar(300), @startDate datetime, @endDate datetime)" +
            " AS" +
            " SELECT s.CompanyName as SupplierName, SUM(od.UnitPrice * od.Quantity) as TotalPrice" +
            " FROM Suppliers s" +
            " JOIN Products p" +
            " ON s.SupplierID = p.SupplierID AND s.CompanyName = @supplierName" +
            " JOIN [Order Details] od" +
            " ON od.ProductID = p.ProductID" +
            " JOIN Orders o" +
            " ON o.OrderID = od.OrderID AND o.OrderDate >= @startDate and o.OrderDate <= @endDate" +
            " GROUP BY s.CompanyName" +
            " ORDER BY s.CompanyName";

            nwEntities.Database.ExecuteSqlCommand(check);
            nwEntities.Database.ExecuteSqlCommand(query);
        }
    }
}
