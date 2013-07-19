using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MissCat2011
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int one = 0;
            int two = 0;
            int three = 0;
            int four = 0;
            int five = 0;
            int six = 0;
            int seven = 0;
            int eight = 0;
            int nine = 0;
            int ten = 0;
            int vote;

            if (n >= 1 && n <= 100000)
            {
                for (int a = 1; a <= n; a++)
                {
                    vote = int.Parse(Console.ReadLine());
                    if (vote >= 1 && vote <= 10)
                    {
                        if (vote == 1)
                        {
                            one++;
                        }
                        if (vote == 2)
                        {
                            two++;
                        }
                        if (vote == 3)
                        {
                            three++;
                        }
                        if (vote == 4)
                        {
                            four++;
                        }
                        if (vote == 5)
                        {
                            five++;
                        }
                        if (vote == 6)
                        {
                            six++;
                        }
                        if (vote == 7)
                        {
                            seven++;
                        }
                        if (vote == 8)
                        {
                            eight++;
                        }
                        if (vote == 9)
                        {
                            nine++;
                        }
                        if (vote == 10)
                        {
                            ten++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                Environment.Exit(0);
            }
            if (one >= two && one >= three && one >= four && one >= five && one >= six && one >= seven && one >= eight && one >= nine && one >= ten)
            {
                Console.WriteLine(1);
            }
            if (two >= one && two >= three && two >= four && two >= five && two >= six && two >= seven && two >= eight && two >= nine && two >= ten)
            {
                Console.WriteLine(2);
            }
            if (three >= one && three >= two && three >= four && three >= five && three >= six && three >= seven && three >= eight && three >= nine && three >= ten)
            {
                Console.WriteLine(3);
            }
            if (four >= one && four >= two && four >= three && four >= five && four >= six && four >= seven && four >= eight && four >= nine && four >= ten)
            {
                Console.WriteLine(4);
            }
            if (five >= one && five >= two && five >= four && five >= three && five >= six && five >= seven && five >= eight && five >= nine && five >= ten)
            {
                Console.WriteLine(5);
            }
            if (six >= one && six >= two && six >= four && six >= five && six >= three && six >= seven && six >= eight && six >= nine && six >= ten)
            {
                Console.WriteLine(6);
            }
            if (seven >= one && six >= two && seven >= four && seven >= five && seven >= six && seven >= three && seven >= eight && seven >= nine && seven >= ten)
            {
                Console.WriteLine(7);
            }
            if (eight >= one && eight >= two && eight >= four && eight >= five && eight >= six && eight >= seven && eight >= three && eight >= nine && eight >= ten)
            {
                Console.WriteLine(8);
            }
            if (nine >= one && nine >= two && nine >= four && nine >= five && nine >= six && nine >= seven && nine >= eight && nine >= three && nine >= ten)
            {
                Console.WriteLine(9);
            }
            if (ten >= one && ten >= two && ten >= four && ten >= five && ten >= six && ten >= seven && ten >= eight && ten >= nine && ten >= three)
            {
                Console.WriteLine(10);
            }
        }
    }
}
