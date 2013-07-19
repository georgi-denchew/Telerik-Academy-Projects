using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Numerics;

namespace AstrologicalDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string str = Console.ReadLine();
            int result = 0;
            int sum = 0;

            do
            {
                foreach (char ch in str)
                {
                    if (ch != '.' && ch != '-')
                    {
                        string tempstr = Convert.ToString(ch);
                        int temp = Convert.ToInt32(tempstr);
                        sum += temp;
                    }

                    else
                    {
                        continue;
                    }
                }
                str = Convert.ToString(sum);
                result = sum;
                sum = 0;
            }
            while (result > 9);

            Console.WriteLine(result);
        }
    }
}