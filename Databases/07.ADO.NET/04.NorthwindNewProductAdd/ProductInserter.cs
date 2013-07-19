using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TASK 04
// Write a method that adds a new product in the 
// products table in the Northwind database. 
// Use a parameterized SQL command.

namespace _04.NorthwindNewProductAdd
{
    class ProductInserter
    {
        static void Main(string[] args)
        {
            OpenConnection();

            string productName = "New Product";
            int supplierID = 2;
            int categoryID = 3;
            string quantityPerUnit = "1 box";
            decimal unitPrice = 1000;
            short unitsInStock = 19;
            short unitsOnOrder = 40;
            short reorderLevel = 25;
            bool discontinued = true;
            
            Insert(productName, supplierID, categoryID, quantityPerUnit,
                unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
        }

        private static void Insert(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {
            SqlCommand cmdInsertProduct = new SqlCommand(
                "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, " +
                "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, " +
                "@unitsOnOrder, @reorderLevel, @discontinued)", dbCon);

            cmdInsertProduct.Parameters.AddWithValue("@productName", productName);
            cmdInsertProduct.Parameters.AddWithValue("@supplierID", supplierID);
            cmdInsertProduct.Parameters.AddWithValue("@categoryID", categoryID);
            cmdInsertProduct.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmdInsertProduct.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmdInsertProduct.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            cmdInsertProduct.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            cmdInsertProduct.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmdInsertProduct.Parameters.AddWithValue("@discontinued", discontinued);

            cmdInsertProduct.ExecuteNonQuery();
            
        }

        private static SqlConnection dbCon;
        private static void OpenConnection()
        {
            dbCon = new SqlConnection("Server=LOCALHOST; Database=Northwind; Integrated Security=true");
            dbCon.Open();
        }
    }
}
