using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public class XMLGenerator
    {
        private static void GenerateSalesReport(IQueryable xmlDataQuery)
        {

            XElement sales = new XElement("sales");

            foreach (XmlSalesContainer item in xmlDataQuery)
            {
                XElement summary = new XElement("summary");
                
                summary.SetAttributeValue("total-sum", item.Sum);
                summary.SetAttributeValue("date", item.Date.ToShortDateString());

                XElement existingSale = sales.Elements().FirstOrDefault(x => x.Attribute("vendor").Value == item.VendorName);

                if (existingSale == null)
                {
                    XElement sale = new XElement("sale");
                    sale.SetAttributeValue("vendor", item.VendorName);

                    sale.Add(summary);
                    sales.Add(sale);
                }
                else
                {
                    existingSale.Add(summary);
                }
            }


            sales.Save("../../sales-report.xml");
        }


        internal static void GenerateSalesReport()
        {
            using (SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer spEntSQLServer 
                = new SQLServer.Data.EntityFramework.SupermarketEntitiesSQLServer())
            {
                var xmlDataQuery =
                from v in spEntSQLServer.Vendors
                join p in spEntSQLServer.Products
                on v.ID equals p.VendorId
                join s in spEntSQLServer.Sales
                on p.ID equals s.ProductID
                join d in spEntSQLServer.Dates
                on s.DateID equals d.ID
                group new
                {
                    s,
                    v
                }
                by new
                {
                    v.Name,
                    s.Date
                } into grouped

                select new XmlSalesContainer
                {
                    Date = grouped.Key.Date.DateAndTime,
                    VendorName = grouped.Key.Name,
                    Sum = grouped.Sum(x => x.s.Sum)
                };

                GenerateSalesReport(xmlDataQuery);
            }
        }
    }
}