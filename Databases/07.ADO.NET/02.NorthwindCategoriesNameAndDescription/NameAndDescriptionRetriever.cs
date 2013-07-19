using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TASK 02 Write a program that retrieves the name
// and description of all categories in the Northwind DB.

namespace _02.NorthwindCategoriesNameAndDescription
{
    class NameAndDescriptionRetriever
    {
        static void Main(string[] args)
        {
            OpenConnection();

            using (dbCon)
            {
                string query = "SELECT c.CategoryName, c.Description FROM Categories c";
                
                SqlCommand cmd = new SqlCommand(query, dbCon);
                SqlDataReader reader = cmd.ExecuteReader();

                PrintNameAndDescription(reader);
            }
        }

        private static void PrintNameAndDescription(SqlDataReader reader)
        {
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("Name: {0}; Description: {1}", name, description);
                }
            }
        }

        private static SqlConnection dbCon;
        private static void OpenConnection()
        {
            dbCon = new SqlConnection(Settings.Default.DBConnectionString);
            dbCon.Open();
        }
    }
}
