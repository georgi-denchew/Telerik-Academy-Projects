namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using MongoDBController;
    using SQLServer.Data.EntityFramework;
    using SQLServer.Models.EntityFramework;

    public static class XMLCustomReader
    {
        public static void ReadExpesnses(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlElement item in rootNode)
            {
                XMLData data = new XMLData();

                data.Vendor = item.GetAttribute("vendor");

                foreach (XmlElement sale in item)
                {
                    data.CurrentExpenseDate = DateTime.Parse(sale.GetAttribute("month"));
                    data.Expense = decimal.Parse(sale.InnerText);

                    SaveData(data);
                }
            }
        }

        public static void SaveData(XMLData data)
        {
            using (SupermarketEntitiesSQLServer marketContext
                = new SupermarketEntitiesSQLServer())
            {
                MongoDBProvider mnogoContext = new MongoDBProvider();
                Expense expenseToInsert = new Expense();

                expenseToInsert.CurrentExpense = data.Expense;
                expenseToInsert.CurrentMonth = data.CurrentExpenseDate;
                expenseToInsert.VendorName = data.Vendor;

                // Save to Mnogo DB
                mnogoContext.InsertExpence(expenseToInsert);

                // Save to MSSQL server
                marketContext.Expenses.Add(expenseToInsert);

                marketContext.SaveChanges();
            }
        }
    }
}
