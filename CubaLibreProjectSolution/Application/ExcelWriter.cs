namespace Application
{
    using System.IO;
    using MongoDBController;
    using SQLite.Models.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    
    public class ExcelWriter
    {
        internal static void GenerateExcel()
        {
            using (TaxesEntities taxesEntities = new TaxesEntities())
            {
                IQueryable<ExcelProductReport> searchQuery =
                    from e in taxesEntities.Expences
                    join r in taxesEntities.Reports
                    on e.VendorName equals r.VendorName
                    join t in taxesEntities.Taxes
                    on r.ProductName equals t.ProductName
                    where e.CurrentMoth.Month == DateTime.Now.Month 
                    group new
                    {
                        e,
                        r,
                        t
                    } by new
                    {
                        e.VendorName,

                    } into grouped
                    select new ExcelProductReport
                    {
                        VendorName = grouped.Key.VendorName,
                        Income = grouped.Sum(x => x.r.TotalIncome),
                        Expences = grouped.Sum(x => x.e.CurrentExpence),
                        Taxes = grouped.Sum(x => x.t.Tax1)
                    };

                GenerateExcel(searchQuery, "../../report.xlsx");
            }
        }

        public static void GenerateExcel(IQueryable<ExcelProductReport> items, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            string strAccessConn = string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 xml'", path);

            // Create the dataset and add the Categories table to it:
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }

            InsertIntoExcelDoc(myAccessConn, items);
        }

        public static void InsertIntoExcelDoc(OleDbConnection dbConnect, IQueryable<ExcelProductReport> items)
        {
            dbConnect.Open();

            OleDbCommand cmd = new OleDbCommand(@"CREATE TABLE [Sheet33] ([Vendor Name] string, [Incomes] int, [Expenses] int, [Taxes] int, [Financial Result] int)", dbConnect);
            cmd.ExecuteScalar();

            foreach (var vendor in items)
            {
                OleDbCommand insertQuery = new OleDbCommand(
                    "INSERT INTO [Sheet33$] ([Vendor Name], [Incomes], [Expenses], [Taxes], [Financial Result])  VALUES (@vendorName, @income, @expenses, @taxes, @finResults)", dbConnect);

                insertQuery.Parameters.AddWithValue("@vendorName", vendor.VendorName);
                insertQuery.Parameters.AddWithValue("@income", vendor.Income);
                insertQuery.Parameters.AddWithValue("@expenses", vendor.Expences);
                insertQuery.Parameters.AddWithValue("@taxes", vendor.Taxes);
                insertQuery.Parameters.AddWithValue("@finResults", (vendor.Income - vendor.Taxes - vendor.Expences));

                insertQuery.ExecuteNonQuery();
            }

            dbConnect.Close();
        }
    }
}
