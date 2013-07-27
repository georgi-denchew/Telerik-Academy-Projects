namespace SQLServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;

    public class Vendor
    {
        private ICollection<Product> products;

        public Vendor()
        {
            this.Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}