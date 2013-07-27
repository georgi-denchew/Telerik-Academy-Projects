namespace SQLServer.Data.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using SQLServer.Models.EntityFramework;

    public class SupermarketEntitiesSQLServer : DbContext
    {
        public SupermarketEntitiesSQLServer()
            : base("SupermarketsDbSQLServer")
        {
        }

        public DbSet<Date> Dates { get; set; }

        public DbSet<Sale> Sales { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Supermarket> Supermarkets { get; set; }

        public DbSet<Expense> Expenses { get; set; }
    }
}
