using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TASK 06
// Create an Excel file with 2 columns: name and score:
// Write a program that reads your MS Excel file 
// through the OLE DB data provider and displays 
// the name and score row by row.

namespace _07.ExcelNameAndScoreExtract
{
    class NameAndScoreGetter
    {
        static void Main(string[] args)
        {
            OleDbConnectionStringBuilder connectionBuilder = new OleDbConnectionStringBuilder();
            connectionBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            connectionBuilder.DataSource = @"..\..\table.xlsx";
            connectionBuilder.Add("Extended Properties", "Excel 12.0 Xml; HRD=YES");

            OpenConnection(connectionBuilder.ConnectionString);

            FillTable();
            CloseConnection();
            PrintRows();
        }

        private static void PrintRows()
        {
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();
            }
        }

        private static void FillTable()
        {
            using (connection)
            {
                string query = @"SELECT * FROM [sheet1$]";

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

                using (adapter)
                {
                    adapter.FillSchema(dt, SchemaType.Source);
                    adapter.Fill(dt);
                }
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
