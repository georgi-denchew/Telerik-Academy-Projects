using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IEnumerableExtensions
{
    public static class IEnumerableExtensions
    {
        public static decimal Sum<T>(this IEnumerable<T> enumeration)
        {
            dynamic sum = 0;

            foreach (var item in enumeration)
            {
                sum += item;
            }

            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> enumeration)
        {
            dynamic product = 1;

            foreach (var item in enumeration)
            {
                product *= item;
            }
            return product;
        }

        public static decimal Min<T>(this IEnumerable<T> enumeration)
        {
            dynamic min = 0;
            int count = 0;

            foreach (var item in enumeration)
            {
                if (count == 0)
                {
                    min = item;
                    count++;
                }
                else if (min > item)
                {
                    min = item;
                }
            }
            return min;
        }

        public static decimal Max<T>(this IEnumerable<T> enumeration)
        {
            dynamic max = 0;
            int count = 0;

            foreach (var item in enumeration)
            {
                if (count == 0)
                {
                    max = item;
                    count++;
                }
                else if (max < item)
                {
                    max = item;
                }
            }

            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> enumeration)
        {
            decimal count = 0;

            foreach (var item in enumeration)
            {
                count++;
            }

            return enumeration.Sum() / count;
        }
    }
}
