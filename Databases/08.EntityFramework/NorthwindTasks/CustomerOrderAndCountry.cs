using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTasks
{
    public class CustomerOrderAndCountry
    {
        public string CompanyName { get; set; }

        public override string ToString()
        {
            return string.Format("Company Name: {0}",this.CompanyName);
        }
    }
}
