using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    public class MortgageAccount : Account, IDeposit
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { 
        }

        public override decimal CalculateInterestAmount(decimal months)
        {
            if (this.customer is Company)
            {
                if (months <= 12)
                {
                    return base.CalculateInterestAmount(months) / 2;
                }
                else
                {
                    return base.CalculateInterestAmount(12) / 2 + base.CalculateInterestAmount(months - 12);
                }
            }
            else 
            {
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmount(months - 6);
                }
            }
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }
        
    }
}
