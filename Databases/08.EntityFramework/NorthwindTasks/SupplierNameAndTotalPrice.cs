using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTasks
{
    class SupplierNameAndTotalPrice
    {
        public string SupplierName { get; set; }
        public decimal TotalPrice { get; set; }

        public override string ToString()
        {
            return string.Format("Supplier Name: {0}; Total Price: {1};", this.SupplierName, this.TotalPrice);
        }
    }
}
