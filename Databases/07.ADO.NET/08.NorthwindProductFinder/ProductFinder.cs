using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TASK 08
//Write a program that reads a 
//string from the console and finds all 
//that contain this string. Ensure you 
//handle correctly characters like ', %, ", \ and _.

namespace _08.NorthwindProductFinder
{
    class ProductFinder
    {
        static void Main(string[] args)
        {
            Console.Write("Enter product-search string: ");

            string productString = Console.ReadLine();

            productString = InsertEscapingCharacter(productString);

            OpenConnection();

            GetProductNames(productString);

            Console.WriteLine(output);
        }

        private static void GetProductNames(string productString)
        {
            using (dbCon)
            {
                string query = "SELECT ProductName FROM Products " +
                    "WHERE ProductName LIKE '%" + productString + "%' ESCAPE '~'";

                SqlCommand command = new SqlCommand(query, dbCon);
                SqlDataReader reader = command.ExecuteReader();

                GetProductNames(reader);
            }
        }

        private static void GetProductNames(SqlDataReader reader)
        {
            using (reader)
            {
                output.Append("Products: ");

                while (reader.Read())
                {
                    output.AppendFormat("{0}, ", reader["ProductName"]);
                }
            }

            output.Length -= 2;
        }

        private static string InsertEscapingCharacter(string productString)
        {
            productString = productString.Replace("%", "~%");
            productString = productString.Replace("'", "''");
            productString = productString.Replace("\"", "~\"");
            productString = productString.Replace("\\", "~\\");
            productString = productString.Replace("_", "~_");
            return productString;
        }

        private static StringBuilder output = new StringBuilder();
        private static SqlConnection dbCon;
        private static void OpenConnection()
        {
            dbCon = new SqlConnection("Server=LOCALHOST; Database=Northwind; Integrated Security=true");
            dbCon.Open();

            
        }

        private static void CloseConnection()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }
    }
}
