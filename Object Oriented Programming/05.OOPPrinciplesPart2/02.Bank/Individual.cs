using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    public class Individual : Customer
    {
        public Individual(string name, long identificationNumber)
            : base(name, identificationNumber)
        {
        }

        public override string ToString()
        {
            return String.Format("{0} - Individual customer", this.name);
        }
    }
}
