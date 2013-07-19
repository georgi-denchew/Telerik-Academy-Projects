using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static int n;
    static  List<string> result = new List<string>();
    static char[] temp;
    static byte[] segments = new byte[n];
    

    static  byte[] digits = new byte[10]
        {
            Convert.ToByte("1111110", 2),
            Convert.ToByte("0110000", 2),
            Convert.ToByte("1101101", 2),
            Convert.ToByte("1111001", 2),
            Convert.ToByte("0110011", 2),
            Convert.ToByte("1011011", 2),
            Convert.ToByte("1011111", 2),
            Convert.ToByte("1110000", 2),
            Convert.ToByte("1111111", 2),
            Convert.ToByte("1111011", 2),
        };

    static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        segments = new byte[n];
        temp = new char[n];
        for (int i = 0; i < n; i++)
        {
            segments[i] = Convert.ToByte(Console.ReadLine(), 2);
        }
        Recursion(0);

        Console.WriteLine(result.Count);
        foreach (string answer in result)
        {
            Console.WriteLine(answer);
        }
    }
    static void Recursion(int position)
    {
        if (position == n)
        {
            result.Add(new string(temp));
            return;
        }
        for (int i = 0; i < digits.Length; i++)
        {
            if ((digits[i] & segments[position]) == segments[position])
            {
                temp[position] = (char)('0' + i);
                Recursion(position + 1);
            }
        }
    }
}