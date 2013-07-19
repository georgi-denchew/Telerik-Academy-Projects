using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ConvertFromStoD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            string n = Console.ReadLine();
            int resultTemp = 0;
            string result = "";
            Console.Write("Enter base S: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Enter base D: ");
            int d = int.Parse(Console.ReadLine());
            for (int i = 0; i < n.Length; i++)
            {
                resultTemp += Convert.ToInt32(n.Substring(i, 1)) * (int)Math.Pow(s, n.Length - 1 - i);

            }

            while (resultTemp > 0)
            {
                switch (resultTemp % d)
                {
                    case 0: result += "0"; break;
                    case 1: result += "1"; break;
                    case 2: result += "2"; break;
                    case 3: result += "3"; break;
                    case 4: result += "4"; break;
                    case 5: result += "5"; break;
                    case 6: result += "6"; break;
                    case 7: result += "7"; break;
                    case 8: result += "8"; break;
                    case 9: result += "9"; break;
                    case 10: result += "a"; break;
                    case 11: result += "b"; break;
                    case 12: result += "c"; break;
                    case 13: result += "d"; break;
                    case 14: result += "e"; break;
                    case 15: result += "f"; break;
                    default: result += ""; break;
                }

                resultTemp = resultTemp / d;
            }

            char[] arr = result.ToCharArray();
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
    }
}