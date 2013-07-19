using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;

// TASK 01
// Write a program that retrieves from the Northwind sample database 
// in MS SQL Server the number of rows in the Categories table.

namespace _01.NorthwindRowsNumber
{
    class RowsCalculator
    {
        static void Main(string[] args)
        {
            OpenConnection();

            string table = "Categories";
            int rows = FindRows(table);
            
            Console.WriteLine("Number of rows in the table {0}: {1}", table, rows);

            CloseConnection();
        }

        private static SqlConnection dbCon;

        private static void OpenConnection()
        {
            dbCon = new SqlConnection(Settings.Default.DBConnectingString);
            dbCon.Open();
        }

        private static int FindRows(string table)
        {
            SqlCommand cmd = new SqlCommand(string.Format("SELECT COUNT(*) FROM {0}", table), dbCon);
            return (int)cmd.ExecuteScalar();
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
