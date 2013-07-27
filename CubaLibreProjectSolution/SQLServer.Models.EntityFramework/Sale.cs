namespace SQLServer.Models.EntityFramework
{
    using System;

    public class Sale
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Sum { get; set; }

        public int DateID { get; set; }

        public virtual Date Date { get; set; }

        public int SupermarketID { get; set; }

        public virtual Supermarket Supermarket { get; set; }
    }
}
