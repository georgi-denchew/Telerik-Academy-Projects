using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    public class Company : Customer
    {
        public Company(string name, long identificationNumber)
            : base(name, identificationNumber)
        {
        }

        public override string ToString()
        {
            return String.Format("{0} - Company customer", this.name);
        }
    }
}
