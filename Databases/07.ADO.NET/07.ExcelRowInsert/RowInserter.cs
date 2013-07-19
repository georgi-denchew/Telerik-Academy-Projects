using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TASK 07 Implement appending new rows to the Excel file.

namespace _07.ExcelRowInsert
{
    class RowInserter
    {
        static void Main(string[] args)
        {
            string name = "New Name";
            string score = "6";

            OleDbConnectionStringBuilder connectionBuilder = new OleDbConnectionStringBuilder();
            connectionBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            connectionBuilder.DataSource = @"..\..\table.xlsx";
            connectionBuilder.Add("Extended Properties", "Excel 12.0 Xml; HRD=YES");

            OpenConnection(connectionBuilder.ConnectionString);

            InsertRow(name, score);            

            CloseConnection();
        }

        private static void InsertRow(string name, string score)
        {
            using (connection)
            {
                string insertCommand = string.Format("INSERT INTO [Sheet1$] (Name, Score)" +
                    "Values('" + name + "', '" + score + "')");
                OleDbCommand cmd = new OleDbCommand(insertCommand, connection);
                cmd.ExecuteNonQuery();
            }
        }

        private static OleDbConnection connection;
        private static DataTable dt = new DataTable();

        private static void OpenConnection(string connectionString)
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();
        }

        private static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
