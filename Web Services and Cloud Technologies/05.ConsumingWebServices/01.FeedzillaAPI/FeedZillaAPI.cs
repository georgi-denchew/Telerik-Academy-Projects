using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace _01.FeedzillaAPI
{
    class FeedZillaAPI
    {
        private static ArticlesCollection allArticles;
        private static HttpClient httpClient = new HttpClient();
        private static string queryString;
        private static int count;

        static void Main(string[] args)
        {
            InitializeClient();
            ReadInput();
            GetResult();
            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (Article article in allArticles.articles)
            {
                Console.WriteLine(article.ToString());
            }
        }

        private static void GetResult()
        {
            var response = httpClient.GetAsync("?q=" + queryString + "&count=" + count).Result.Content.ReadAsStringAsync().Result;

            allArticles = JsonConvert.DeserializeObject<ArticlesCollection>(response);
        }

        private static void ReadInput()
        {
            Console.Write("Enter query string: ");
            queryString = Console.ReadLine();
            Console.Write("Enter results count: ");
            count = int.Parse(Console.ReadLine());
        }
        private static void InitializeClient()
        {
            httpClient.BaseAddress =
                        new Uri("http://api.feedzilla.com/v1/articles/search.json");
        }
    }
}
