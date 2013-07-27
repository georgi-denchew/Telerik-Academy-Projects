namespace Application
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using SQLite.Models.EntityFramework;
    using MongoDBController;

    internal class DatabaseUtilites
    {

        public static void FillSQLite()
        {

            using (TaxesEntities taxes = new TaxesEntities())
            {
                var mongo = new MongoDBProvider();

                var allExpences = mongo.ListAllExpenses();
                var allReporst = mongo.ListAllReports();

                foreach (var report in allReporst)
                {
                    Report reportToInsert = new Report();
                    reportToInsert.TotalIncome = report.TotalIncomes;
                    reportToInsert.TotalQuantitySold = report.TotalQuantitySold;
                    reportToInsert.VendorName = report.VendorName;
                    reportToInsert.ProductName = report.ProductName;

                    taxes.Reports.Add(reportToInsert);

                }

                taxes.SaveChanges();

                foreach (var expence in allExpences)
                {
                    Expence expenceToInsert = new Expence();
                    expenceToInsert.CurrentExpence = expence.CurrentExpense;
                    expenceToInsert.CurrentMoth = expence.CurrentMonth;
                    expenceToInsert.VendorName = expence.VendorName;

                    taxes.Expences.Add(expenceToInsert);

                }


                taxes.SaveChanges();
            }
        }

        /// <summary>
        /// Copy data from MySQL Database to MSSQL Sever Database
        /// </summary>
        /// <param name="spEntMySQL">MySQL entity</param>
        /// <param name="spEntSQLServer">MSSQL Serve entity</param>
        internal static void MigrateData(
            MySQL.Models.OpenAccess.SupermarketEntitiesMySQL spEntMySQL,
            SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer spEntSQLServer)
        {
            if (spEntSQLServer.Database.Exists())
            {
                return;
            }

            // Insert Measures
            foreach (var measure in spEntMySQL.Measures)
            {
                SQLServer.Models.EntityFramework.Measure measureToInsert =
                    new SQLServer.Models.EntityFramework.Measure();

                measureToInsert.ID = measure.MeasureID;
                measureToInsert.Name = measure.MeasureName;

                spEntSQLServer.Measures.Add(measureToInsert);
            }

            // Inserting Vendors
            foreach (var vendor in spEntMySQL.Vendors)
            {
                SQLServer.Models.EntityFramework.Vendor vendorToInsert =
                    new SQLServer.Models.EntityFramework.Vendor();

                vendorToInsert.ID = vendor.VendorID;
                vendorToInsert.Name = vendor.VendorName;

                spEntSQLServer.Vendors.Add(vendorToInsert);
            }

            // Inserting Products
            foreach (var product in spEntMySQL.Products)
            {
                SQLServer.Models.EntityFramework.Product productToInsert =
                    new SQLServer.Models.EntityFramework.Product();

                productToInsert.ID = product.ProductID;
                productToInsert.MeasureId = product.MeasureID;
                productToInsert.ProductName = product.ProductName;
                productToInsert.VendorId = product.VendorID;
                productToInsert.BasePrice = product.BasePrice;

                spEntSQLServer.Products.Add(productToInsert);
            }

            spEntSQLServer.SaveChanges();
        }

        internal static void FillExcelData(
            SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer spEntSQLServer)
        {
            foreach (var excelRow in ExcelReader.AllSales)
            {
                int dateID = InsertDate(spEntSQLServer, excelRow);

                int supermarketID = InsertSupermarket(spEntSQLServer, excelRow);

                InsertSale(spEntSQLServer, excelRow, dateID, supermarketID);
            }
        }

        private static int InsertSale(
            SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer spEntSQLServer,
            ExcelData excelRow, 
            int dateID, 
            int supermarketID)
        {
            SQLServer.Models.EntityFramework.Sale saleToInsert = new SQLServer.Models.EntityFramework.Sale();
            saleToInsert.ProductID = excelRow.ProductID;
            saleToInsert.SupermarketID = supermarketID;
            saleToInsert.DateID = dateID;
            saleToInsert.Quantity = excelRow.Quantity;
            saleToInsert.Sum = excelRow.Sum;
            saleToInsert.UnitPrice = excelRow.UnitPrice;
            var a = spEntSQLServer.Sales.Add(saleToInsert);

            spEntSQLServer.SaveChanges();

            return a.ID;
        }

        private static int InsertSupermarket(SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer spEntSQLServer, ExcelData excelRow)
        {
            var existingSupermarket = spEntSQLServer.Supermarkets.FirstOrDefault(s => s.Name == excelRow.SupermarketName);

            if (existingSupermarket == null)
            {
                SQLServer.Models.EntityFramework.Supermarket supermarketToInsert = new SQLServer.Models.EntityFramework.Supermarket();
                supermarketToInsert.Name = excelRow.SupermarketName;
                var result = spEntSQLServer.Supermarkets.Add(supermarketToInsert);

                spEntSQLServer.SaveChanges();

                return result.SupermarketId;
            }
            else
            {
                return existingSupermarket.SupermarketId;
            }
        }

        private static int InsertDate(
            SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer spEntSQLServer,
            ExcelData excelRow)
        {
            var existingDate = spEntSQLServer.Dates.FirstOrDefault(d => d.DateAndTime == excelRow.SaleDate);

            if (existingDate == null)
            {
                SQLServer.Models.EntityFramework.Date dateToInsert = new SQLServer.Models.EntityFramework.Date();
                dateToInsert.DateAndTime = excelRow.SaleDate;
                var result = spEntSQLServer.Dates.Add(dateToInsert);

                spEntSQLServer.SaveChanges();

                return result.ID;
            }
            else
            {
                return existingDate.ID;
            }
        }

        internal static void AggregatePDF(
            SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer spEntSQLServer,
            DateTime startDate, 
            DateTime endDate)
        {
            FileStream file = new FileStream(@"../../Reports.pdf", FileMode.Append);

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, file);

            doc.Open();

            PdfPTable table = new PdfPTable(5);
            table.TotalWidth = 416f;
            table.LockedWidth = true;

            PdfPCell cell = new PdfPCell(new Phrase("Aggregated Sales Report"));
            cell.Colspan = 5;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            decimal grandSum = 0;
            using (spEntSQLServer)
            {
                var dates =
                    from d in spEntSQLServer.Dates
                    where d.DateAndTime >= startDate && d.DateAndTime <= endDate
                    select d;

                foreach (var date in dates)
                {
                    PdfPCell cellDate = new PdfPCell(new Phrase("Date : " + date.DateAndTime.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US"))));

                    cellDate.Colspan = 5;
                    cellDate.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(cellDate);
                    PdfPCell cellProduct = new PdfPCell(new Phrase("Products"));
                    cellProduct.BackgroundColor = BaseColor.LIGHT_GRAY;
                    PdfPCell cellQuantity = new PdfPCell(new Phrase("Quantity"));
                    cellQuantity.BackgroundColor = BaseColor.LIGHT_GRAY;
                    PdfPCell cellUnitPrice = new PdfPCell(new Phrase("Unit Price"));
                    cellUnitPrice.BackgroundColor = BaseColor.LIGHT_GRAY;
                    PdfPCell cellLocation = new PdfPCell(new Phrase("Location"));
                    cellLocation.BackgroundColor = BaseColor.LIGHT_GRAY;
                    PdfPCell cellSum = new PdfPCell(new Phrase("Sum"));
                    cellSum.BackgroundColor = BaseColor.LIGHT_GRAY;

                    table.AddCell(cellProduct);
                    table.AddCell(cellQuantity);
                    table.AddCell(cellUnitPrice);
                    table.AddCell(cellLocation);
                    table.AddCell(cellSum);

                    decimal totalSum = 0;

                    SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer sqlServer =
                        new SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer();

                    using (sqlServer)
                    {
                        var sales =
                            from s in sqlServer.Sales
                            where s.Date.DateAndTime == date.DateAndTime
                            select s;

                        foreach (var sale in sales.ToList())
                        {
                            if (sale.Product.ProductName != null)
                            {
                                table.AddCell(sale.Product.ProductName.ToString());
                                table.AddCell(sale.Quantity.ToString());
                                table.AddCell(sale.UnitPrice.ToString());
                                table.AddCell(sale.Supermarket.Name.ToString());
                                table.AddCell(sale.Sum.ToString());

                                totalSum += sale.Sum;
                            }
                        }
                    }

                    string text = string.Format("Total sum for {0} :", startDate.ToString("yyyy-MMM-dd", CultureInfo.CreateSpecificCulture("en-US")));
                    PdfPCell cellTotal = new PdfPCell(new Phrase(text));
                    cellTotal.Colspan = 4;
                    cellTotal.HorizontalAlignment = 2;
                    table.AddCell(cellTotal);
                    table.AddCell(totalSum.ToString());

                    grandSum += totalSum;
                }
            }

            string grand = string.Format("Grand Total: ");
            PdfPCell cellGrand = new PdfPCell(new Phrase(grand));
            cellGrand.Colspan = 4;
            cellGrand.HorizontalAlignment = 2;
            table.AddCell(cellGrand);
            table.AddCell(grandSum.ToString());

            doc.Add(table);
            doc.Close();
        }
    }
}
