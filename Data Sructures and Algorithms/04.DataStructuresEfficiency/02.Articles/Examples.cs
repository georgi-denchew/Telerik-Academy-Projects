namespace _02.Articles
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    class Examples
    {
        static void Main(string[] args)
        {

            Company company = new Company();
            Random rand = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                company.AddArtile((i * 123).ToString(), string.Format("vendor{0}", i),
                    string.Format("Title{0}", i), rand.NextDouble() * 1000);
            }

            for (int i = 0; i < 50000; i++)
            {
                double firstRandom = rand.NextDouble() * 1000;
                double secondRandom = rand.NextDouble() * 1000;

                double minPrice = Math.Abs(firstRandom - secondRandom);

                double maxPrice = firstRandom.CompareTo(secondRandom) > 0 ? firstRandom : secondRandom;

                var articlesWithPrice = company.ArticlesWithPrice(minPrice, true, maxPrice, true);
            }

            watch.Stop();

            Console.WriteLine("Adding 1 000 000 articles with random prices and searching 50 000 times {0}" +
            "for articles with random minimal and maximal price took {1} seconds", Environment.NewLine, watch.Elapsed);
        }
    }
}
