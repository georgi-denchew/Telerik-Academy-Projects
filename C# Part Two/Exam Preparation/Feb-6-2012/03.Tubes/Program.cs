using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            long tubeSizes = 0;
            List<int> tubes = new List<int>();


            for (int i = 0; i < n; i++)
            {
                int size = int.Parse(Console.ReadLine());
                tubeSizes += size;
                tubes.Add(size);
            }

            if (m > tubeSizes)
            {
                Console.WriteLine(-1);
            }

            int left = 0;
            int right = (int)Math.Ceiling((double)tubeSizes / (double)m);
            while (left < right)
            {
                int count = 0;
                int length = (left + right) / 2;
                if (length == 0)
                {
                    left = 1;
                    break;
                }
                foreach (int tube in tubes)
                {
                    count += tube / length;
                }

                if (count < m)
                {
                    right = length;
                }

                else
                {
                    left = length + 1;
                }
            }

            for (; left >= 1; left--)
            {
                int count = 0;
                foreach (int tube in tubes)
                {
                    count += tube / left;
                }

                if (count >= m)
                {
                    break;
                }
            }
            Console.WriteLine(left);
        }
    }
}