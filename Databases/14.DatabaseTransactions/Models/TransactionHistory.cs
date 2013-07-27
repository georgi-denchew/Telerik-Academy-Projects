using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TransactionHistory
    {
        public TransactionHistory()
        {
        }

        public int ID { get; set; }

        [StringLength(10)]
        public string CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }
    }
}
