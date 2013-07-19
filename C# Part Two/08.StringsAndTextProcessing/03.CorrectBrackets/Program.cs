using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CorrectBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter expression here: ");
            string expression = Console.ReadLine();
            int count = 0;

            try
            {
                foreach (char ch in expression)
                {
                    if (ch == '(')
                    {
                        count++;
                    }
                    else if (ch == ')')
                    {
                        count--;
                    }

                    if (count < 0)
                    {
                        throw new ArgumentException();
                    }
                }

                if (count != 0)
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Brackets are not put correctly.");
            }
        }
    }
}
