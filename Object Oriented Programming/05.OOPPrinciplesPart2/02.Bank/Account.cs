using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    public abstract class Account
    {
        protected Customer customer;
        protected decimal balance;
        protected decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.customer = customer;
            this.balance = balance;
            this.interestRate = interestRate;
        }

        public string Customer
        {
            get { return this.customer.ToString(); }
        }

        public decimal Balance
        {
            get { return this.balance; }
            private set { this.balance = value; }
        }

        public decimal InterestRate // Interest will be given in percentage. Example 12 => 12%
        {
            get { return this.interestRate; }
            private set { this.interestRate = value; }
        }

        public virtual decimal CalculateInterestAmount(decimal months) //That is to be calculated in the common case
        {                                                             //The formula for calculating the simple interest rate is:
             return months * this.interestRate * Math.Abs(this.balance) / 100;  //[(number of months)*(current balance) * (interest rate)] / 100
        }                                                             //NOT [(number of months) * (interest rate)] - the way it is given in the task
    }
}
