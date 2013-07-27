namespace Application
{
    using System;

    public class ExcelData
    {
        public ExcelData(
            DateTime saleDate, 
            string supermarketName, 
            int productID, 
            int quantity, 
            decimal unitPrice, 
            decimal sum)
        {
            this.SaleDate = saleDate;
            this.SupermarketName = supermarketName;
            this.ProductID = productID;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.Sum = sum;
        }

        public DateTime SaleDate { get; set; }

        public string SupermarketName { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Sum { get; set; }
    }
}
