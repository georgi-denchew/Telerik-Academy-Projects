namespace SQLServer.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Measure
    {
        private ICollection<Product> products;

        public Measure()
        {
            this.Products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
