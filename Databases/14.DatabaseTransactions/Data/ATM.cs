using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ATM : DbContext
    {
        public ATM() : base("ATM")
        {
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionHistory> TransactionsHistory { get; set; }
    }
}
