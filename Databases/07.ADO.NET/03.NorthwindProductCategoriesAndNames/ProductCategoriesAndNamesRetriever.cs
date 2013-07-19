using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// TASK 03
// Write a program that retrieves from the
// Northwind database all product categories 
// and the names of the products in each category. 
// Can you do this with a single SQL query (with table join)?

namespace _03.NorthwindProductCategoriesAndNames
{
    class ProductCategoriesAndNamesRetriever
    {
        static void Main(string[] args)
        {
            OpenConnection();

            using (dbCon)
            {
                string query = "SELECT c.CategoryName, p.ProductName " +
                    "FROM Categories c " +
                    "JOIN Products p " +
                    "ON c.CategoryID = p.CategoryID " +
                    "GROUP BY c.CategoryName, p.ProductName";
                
                SqlCommand cmd = new SqlCommand(query, dbCon);
                SqlDataReader reader = cmd.ExecuteReader();

                GetProductsInCategories(reader);

                output.Length -= 2;
                Console.WriteLine(output.ToString());
            }
        }

        private static SqlConnection dbCon;
        private static StringBuilder output = new StringBuilder();

        private static void GetProductsInCategories(SqlDataReader reader)
        {
            using (reader)
            {
                string categoryName = string.Empty;
                string productName = string.Empty;

                while (reader.Read())
                {
                    if (categoryName != (string)reader["CategoryName"])
                    {
                        if (categoryName != string.Empty)
                        {
                            output.Length -= 2;
                            output.AppendLine();
                            output.AppendLine();
                        }

                        categoryName = (string)reader["CategoryName"];
                        output.AppendFormat("Category Name: {0}; Products: ", categoryName);
                    }

                    productName = (string)reader["ProductName"];
                    output.AppendFormat("{0}, ", productName);
                }
            }
        }

        private static void OpenConnection()
        {
            dbCon = new SqlConnection("Server=LOCALHOST; Database=Northwind; Integrated Security=true");
            dbCon.Open();
        }
    }
}
