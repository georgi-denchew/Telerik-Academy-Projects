using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    public class LoanAccount : Account, IDeposit
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestAmount(decimal months)
        {
            if (this.customer is Individual)
            {
                if (months <= 3)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmount(months - 3);
                }
            }

            else
            {
                if (months <= 2)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmount(months - 2);
                }
            }
        }
        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }
    }
}
