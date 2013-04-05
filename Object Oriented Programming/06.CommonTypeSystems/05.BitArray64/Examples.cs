using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitArray64
{
    //TASK 05:Define a class BitArray64 to hold 64 bit 
    //values inside an ulong value. Implement 
    //IEnumerable<int> and Equals(…), GetHashCode(),
    //[], == and !=

    class Examples
    {
        static void Main(string[] args)
        {
            BitArray64 arr1 = new BitArray64(50);
            BitArray64 arr2 = new BitArray64(3);
            BitArray64 arr3 = new BitArray64(50);

            //Console.WriteLine(arr1 == arr2); //uncomment to test

            //Console.WriteLine(arr1 != arr3); //uncomment to test

            //Console.WriteLine(arr2[63]); //uncomment to test

            //Console.WriteLine(arr2[62]); //uncomment to test

            //foreach (var item in arr1)
            //{
            //    Console.Write(item + " "); //uncomment to test
            //}
        }
    }
}
