namespace Application
{
    using System;
    using System.Data.Entity;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Ionic.Zip;
    using MongoDBController;
    using SQLServer.Data.EntityFramework;
    using SQLServer.Data.EntityFramework.Migrations;
    using SQLite.Models.EntityFramework;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Gloabl
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketEntitiesSQLServer, Configuration>());
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // <------------ PDF Generation --------------->

            //using (SupermarketEntitiesSQLServer test = new SupermarketEntitiesSQLServer())
            //{
            //    DatabaseUtilites.AggregatePDF(test, DateTime.Parse("01/01/1990"), DateTime.Parse("01/01/2020"));
            //}

            // <------------ DB Fill --------------->

            //string excelFileDir = @"../../temp";
            //if (Directory.Exists(excelFileDir))
            //{
            //    Directory.Delete(excelFileDir, true);
            //}

            //using (ZipFile zip = ZipFile.Read(@"../../Sample-Sales-Reports.zip"))
            //{
            //    zip.ExtractAll(excelFileDir);

            //    ExcelReader.GetSubDirs(excelFileDir);
            //}

            //using (SupermarketEntitiesSQLServer spEntSQLServer
            //    = new SupermarketEntitiesSQLServer())
            //{
            //    using (MySQL.Models.OpenAccess.SupermarketEntitiesMySQL spEntMySQL
            //    = new MySQL.Models.OpenAccess.SupermarketEntitiesMySQL())
            //    {
            //        DatabaseUtilites.MigrateData(spEntMySQL, spEntSQLServer);
            //        DatabaseUtilites.FillExcelData(spEntSQLServer);

            //    }
            //}

            // <------------ XML Read --------------->

            //XMLCustomReader.ReadExpesnses(@"../../Vendors-Expenses.xml");

            //// <------------ Mongo DB --------------->

            var provider = new MongoDBProvider();
            //provider.DropAllCollections();

            var collection = provider.ListAllExpenses();
            //var sorted = collection.Where(a => a.CurrentMonth.Month == DateTime.Now.Month);

            foreach (var item in collection)
            {
                if (item.CurrentMonth.Month == DateTime.Now.Month)
                {

                }
            }

            provider.InsertProductReports();
            var reportCollection = provider.ListAllReports();

            foreach (var item in reportCollection)
            {
                Console.WriteLine(item);
            }

            provider.SaveProductReportToHDD();

            //// <------------- XML Write --------------->
            //XMLGenerator.GenerateSalesReport();

            //DatabaseUtilites.FillSQLite();

            ExcelWriter.GenerateExcel();
        }
    }
}
