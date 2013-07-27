namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Text;

    public static class ExcelReader
    {
        private static readonly List<ExcelData> allSales = new List<ExcelData>();

        public static List<ExcelData> AllSales
        {
            get
            {
                return allSales;
            }
        }

        public static void GetSubDirs(string path)
        {
            try
            {
                GetExcelInfo(path);

                string[] dirs = Directory.GetDirectories(path);
                
                if (dirs.Length > 0)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        GetSubDirs(dirs[i]);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Directory: {0}, CAN NOT be accessed!", path);
                return;
            }
        }

        private static void GetExcelInfo(string path)
        {
            StringBuilder output = new StringBuilder();

            string[] exes = Directory.GetFiles(path, @"*.xls");

            foreach (var item in exes)
            {
                string strAccessConn = string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    item);

                //Console.WriteLine(item);
                OleDbConnection myAccessConn = new OleDbConnection(strAccessConn);
                myAccessConn.Open();
                DataSet myDataSet = new DataSet();

                // Get all info from the current excel file.
                string strAccessSelect = "SELECT * FROM [Sales$]";

                // Try to open conection
                try
                {
                    myAccessConn = new OleDbConnection(strAccessConn);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                    return;
                }

                // try to exectute command
                try
                {
                    OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                    myAccessConn.Open();
                    myDataAdapter.Fill(myDataSet, "Sales");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                    return;
                }
                finally
                {
                    myAccessConn.Close();
                }

                //DataColumnCollection drc = myDataSet.Tables["Sales"].Columns;
                //foreach (DataColumn dc in drc)
                //{
                //    Console.WriteLine("Column name is {0}, of type {1}", dc.ColumnName, dc.DataType);
                //}

                DataRowCollection excelRows = myDataSet.Tables["Sales"].Rows;
                string supermarketName = string.Empty;
                string saleDate = Path.GetFileName(Path.GetDirectoryName(item));
                int counter = 0;

                foreach (DataRow dataRow in excelRows)
                {
                    counter++;
                    if (counter == 1)
                    {
                        supermarketName = dataRow[0].ToString();
                        continue;
                    }
                    else if (counter == 2 || counter == excelRows.Count)
                    {
                        continue;
                    }

                    int productId = 0;
                    int quantity = 0;
                    decimal unitPrice = 0;
                    decimal sum = 0;

                    int.TryParse(dataRow[0].ToString(), out productId);

                    int.TryParse(dataRow[1].ToString(), out quantity);

                    decimal.TryParse(dataRow[2].ToString(), out unitPrice);

                    decimal.TryParse(dataRow[3].ToString(), out sum);

                    if (productId != 0)
                    {
                        allSales.Add(new ExcelData(DateTime.Parse(saleDate), supermarketName, productId, quantity, unitPrice, sum));
                    }
                        
                    //Console.WriteLine(supermarketName);

                    //Console.WriteLine("{0}, {1}, {2}, {3}", dataRow[0], dataRow[1], dataRow[2], dataRow[3]);

                    //decimal result = 0;

                    //decimal.TryParse(dataRow[0].ToString(), out result);
                    //Console.WriteLine("PARSE: {0}", result);
                }
            }
        }
    }
}
