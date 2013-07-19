using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.ValidationWithRegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "test-1.p46@ala-bala.somehost.somewhere.bg";
            string regex = @"^([a-zA-Z0-9_\-][a-zA-Z0-9_\-\.]{0,49})" +
              @"@(([a-zA-Z0-9][a-zA-Z0-9\-]{0,49}\.)+[a-zA-Z]{2,4})$";
            bool valid = Regex.IsMatch(email, regex);
            Console.WriteLine(valid);
            
        }
    }
}
