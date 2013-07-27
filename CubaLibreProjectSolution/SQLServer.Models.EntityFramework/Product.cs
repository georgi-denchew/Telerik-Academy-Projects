namespace SQLServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Product
    {
        private ICollection<Sale> sales;

        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

        public int ID { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public string ProductName { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }

        public decimal BasePrice { get; set; }
    }
}
