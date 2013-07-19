using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.ProductCollection
{
    class Examples
    {
        static void Main(string[] args)
        {
            // It may seem as the program is a bit slow,
            // but that's only due to the printing on the console.
            // If you discard the printing you will see that all the 
            // processes take no more than 3-5 seconds (depending on CPU)

            OrderedBag<Product> products = new OrderedBag<Product>();

            products.Add(new Product("first", 10));
            products.Add(new Product("second", 300));
            products.Add(new Product("third", 2));

            Random rand = new Random();

            for (int i = 0; i < 500000; i++)
            {
                products.Add(new Product(i.ToString(), rand.NextDouble() * 1000));
            }

            for (int i = 0; i < 10000; i++)
            {
                double firstRandom = rand.NextDouble() * 1000;
                double secondRandom = rand.NextDouble() * 1000;

                double minPrice = Math.Abs(firstRandom - secondRandom);

                double maxPrice = firstRandom.CompareTo(secondRandom) > 0 ? firstRandom : secondRandom;

                var productsInRange = products.Range(new Product("", minPrice), true, new Product("", maxPrice), true);

                Console.WriteLine("First 20 products in the range from {0} to {1} inclusive:", minPrice, maxPrice);
                for (int j = 0; j < 20; j++)
                {
                    if (j < productsInRange.Count)
                    {
                        Console.WriteLine("Name: {0} Price: {1}", productsInRange[j].Name, productsInRange[j].Price);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
