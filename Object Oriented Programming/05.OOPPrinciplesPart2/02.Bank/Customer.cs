using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    public abstract class Customer
    {
        protected string name;
        protected long identificationNumber;

        public Customer(string name, long identificationNumber)
        {
            this.name = name;
            this.identificationNumber = identificationNumber;
        }

        public string Name
        {
            get { return this.name; }
        }

        public long IdentificationNumber
        {
            get { return this.identificationNumber; }
        }
    }
}
