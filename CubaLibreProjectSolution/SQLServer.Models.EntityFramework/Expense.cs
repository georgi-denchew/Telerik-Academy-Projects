namespace SQLServer.Models.EntityFramework
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [Serializable]
    public class Expense
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int ID { get; set; }

        public decimal CurrentExpense { get; set; }

        public string VendorName { get; set; }

        public DateTime CurrentMonth { get; set; }

        public override string ToString()
        {
            return string.Format(
                "ID: {0}, CurrentExpense: {1}, Vendor Name: {2}, CurrentMonth: {3}",
                this.ID,
                this.CurrentExpense,
                this.VendorName,
                this.CurrentMonth
                );
        }
    }
}
