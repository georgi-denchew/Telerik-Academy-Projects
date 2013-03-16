using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    class _Examples
    {
        static void Main(string[] args)
        {
            Individual individual = new Individual("Pesho", 123);

            Console.Write("Individual deposit account interest amount: ");

            DepositAccount individualDeposit = new DepositAccount(individual, 900, 10);
            //individualDeposit.Deposit(200);
            //individualDeposit.Withdraw(100);

            Console.WriteLine(individualDeposit.CalculateInterestAmount(1));

           Console.Write("Individual mortgage account interest amount: ");

            MortgageAccount individualMortgage = new MortgageAccount(individual, 900, 10);
            //individualMortgage.Deposit(100);

            Console.WriteLine(individualMortgage.CalculateInterestAmount(7));

            Console.Write("Individual loan account interest amount: ");

            LoanAccount individualLoan = new LoanAccount(individual, 600, 10);
            individualLoan.Deposit(100);

            Console.WriteLine(individualLoan.CalculateInterestAmount(4));

            Company company = new Company("Pesho Inc.", 1234);

            Console.Write("Company deposit account interest amount: ");

            DepositAccount companyDeposit = new DepositAccount(company, 900, 10);
            companyDeposit.Deposit(100);
            //companyDeposit.Withdraw(200);
            Console.WriteLine(companyDeposit.CalculateInterestAmount(1));

            Console.Write("Company mortgage account interest amount: ");

            MortgageAccount companyMortgage = new MortgageAccount(company, 900, 10);
            companyMortgage.Deposit(100);
            Console.WriteLine(companyMortgage.CalculateInterestAmount(13));

            Console.Write("Company loan account interest amount: ");

            LoanAccount companyLoan = new LoanAccount(company, 900, 10);
            companyLoan.Deposit(100);
            Console.WriteLine(companyLoan.CalculateInterestAmount(1));
        }
    }
}
