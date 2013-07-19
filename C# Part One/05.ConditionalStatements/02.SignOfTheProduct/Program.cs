using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SignOfTheProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program shows the sign of the product of three real numbers without calculating it");
            Console.Write("Enter the first number here: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number here: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number here: ");
            int third = int.Parse(Console.ReadLine());

            if (first == 0)
            {
                Console.WriteLine("The product is 0");
            }

            if (first > 0)
            {
                
                if (second == 0)
                {
                    Console.WriteLine("The product is 0");
                }


                if (second > 0)
                {
                    if (third == 0)
                    {
                        Console.WriteLine("The product is 0");
                    }
                    if (third > 0)
                    {
                        Console.WriteLine("The sign of the product is: +");
                    }
                    if (third < 0)
                    {
                        Console.WriteLine("The sign of the product is: -");
                    }
                    
                }
                
                if (second < 0)
                {
                    
                    if (third == 0)
                    {
                        Console.WriteLine("The product is 0");
                    }
                    
                    if (third > 0)
                    {
                        Console.WriteLine("The sign of the product is: -");
                    }
                    
                    if (third < 0)
                    {
                        Console.WriteLine("The sign of the product is: +");
                    }
                    
                }
                
            }
            
            if (first < 0)
            {
                
                if (second == 0)
                {
                    Console.WriteLine("The product is 0");
                }
                
                if (second > 0)
                {
                    
                    if (third == 0)
                    {
                        Console.WriteLine("The product is 0");
                    }

                    if (third > 0)
                    {
                        Console.WriteLine("The sign of the product is: -");
                    }

                    if (third < 0)
                    {
                        Console.WriteLine("The sign of the product is: +");
                    }
                }
                
                if (second < 0)
                {
                    
                    if (third == 0)
                    {
                        Console.WriteLine("The product is 0");
                    }

                    if (third > 0)
                    {
                        Console.WriteLine("The sign of the product is: +");
                    }

                    if (third < 0)
                    {
                        Console.WriteLine("The sign of the product is: -");
                    }
                    
                }
                
            }
            
        }
    }
}
