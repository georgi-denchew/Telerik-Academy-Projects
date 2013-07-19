using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ExchangingBitsPandQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program exchanges bits p, p + 1, ..., p + k - 1, with bits q, q + 1, ..., q + k - 1, of a given unsigned integer");
            uint number;
            byte p, q, k;
            Console.Write("Enter the uint number here: ");
            bool isNum = uint.TryParse(Console.ReadLine(), out number);
            Console.Write("Enter bit p here: ");
            bool isP = byte.TryParse(Console.ReadLine(), out p);
            Console.Write("Enter bit q here: ");
            bool isQ = byte.TryParse(Console.ReadLine(), out q);
            Console.Write("Enter k here: ");
            bool isK = byte.TryParse(Console.ReadLine(), out k);
            Console.WriteLine("Your number is: {0}", Convert.ToString(number, 2).PadLeft(32, '0'));

            if (( isNum && isP && isQ && isK) && (p < q && (k + q) <= 32))
            {
                while (k != 0)
                {
                    uint maskOne = (uint)(number & (1 << p));
                    uint maskTwo = (uint)(number & (1 << q));
                    
                    if ((maskOne >> p == maskTwo >> q))
                    {
                        goto next;
                    }

                    if ((maskOne >> p != maskTwo >> q) && (maskOne >> p != 0))
                    {
                        int zeroMask = ~(1 << p);
                        number = (uint)(number | (1 << q));
                        number = (uint)(number & zeroMask);
                    }
                    else if ((maskOne >> p != maskOne >> q) && (maskTwo >> q != 0))
                    {
                        int zeroMask = ~(1 << q);
                        number = (uint)(number | (1 << p));
                        number = (uint)(number & zeroMask);
                    }
                next: ;
                p++;
                q++;
                k--;
                }
            Console.WriteLine("New number is:  {0}", Convert.ToString(number, 2).PadLeft(32, '0'));
        }
        else Console.WriteLine("Please enter valid numbers!");
        }
    }
}