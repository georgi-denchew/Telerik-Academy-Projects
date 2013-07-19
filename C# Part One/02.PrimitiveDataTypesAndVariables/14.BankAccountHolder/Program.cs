using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.BankAccountHolder
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstName = "Pesho";
            string MiddleName = "Peshev";
            string LastName = "Peshevski";
            ulong Balance = 123456789;
            string IBAN = "11AB23C578BG";
            string BICCode = "RRTTYYWW";
            ulong CreditCardNo1 = 1111222233334444;
            ulong CreditCardNo2 = 2222333344445555;
            ulong CreditCardNo3 = 3333444455556666;
            Console.WriteLine("First Name:" + FirstName);
            Console.WriteLine("Middle Name:" + MiddleName);
            Console.WriteLine("Last Name:" + LastName);
            Console.WriteLine("Balance:" + Balance);
            Console.WriteLine("IBAN:" + IBAN);
            Console.WriteLine("BIC Code:" + BICCode);
            Console.WriteLine("Credit Card #1:" + CreditCardNo1);
            Console.WriteLine("Credit Card #2:" + CreditCardNo2);
            Console.WriteLine("Credti Card #3:" + CreditCardNo3);
            
        }
    }
}
