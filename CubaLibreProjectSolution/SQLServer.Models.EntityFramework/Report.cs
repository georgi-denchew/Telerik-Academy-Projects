using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Models.EntityFramework
{
    public class Report
    {
        public int ID { get; set; }

        public int DateId { get; set; }

        public virtual Date Date { get; set; }

        public int SupermarketId { get; set; }

        public virtual Supermarket Supermarket { get; set; }

        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
