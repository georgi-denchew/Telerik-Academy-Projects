using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogOfFreeContent;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestCatalog
    {
        [TestMethod]
        public void TestMethodAddSingleItem()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};
            
            ContentItem item = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(item);
            Assert.AreEqual(1, catalog.Count);

            
            //var result = catalog.GetListContent("Intro C#", 1);

            //Assert.AreEqual(result.Count(), 1);
            //Assert.AreSame(result.First(), item);
        }

        [TestMethod]
        public void TestMethodAddAndFindItem()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem item = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(item);

            var result = catalog.GetListContent("Intro C#", 1);

            Assert.AreEqual(result.Count(), 1);
            Assert.AreSame(result.First(), item);
        }

        [TestMethod]
        public void TestMethodAddDuplicatedItem()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem item1 = new ContentItem(ContentType.Book, cmdString);
            ContentItem item2 = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(item1);
            catalog.Add(item2);

            Assert.AreEqual(2, catalog.Count);

        }

        [TestMethod]
        public void TestMethodAddDuplicatedItemSecond()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem item1 = new ContentItem(ContentType.Book, cmdString);
            ContentItem item2 = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(item1);
            catalog.Add(item1);

            Assert.AreEqual(2, catalog.Count);
        }

        [TestMethod]
        public void TestMethodAddMultipleItems()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem book = new ContentItem(ContentType.Book, cmdString);
            ContentItem movie = new ContentItem(ContentType.Movie
                , new string[] { "Java Movie", "James Gosling",
                    "124567", "http://www.java.com" });

            ContentItem javaBook = new ContentItem(ContentType.Book
                , new string[] { "Java Movie", "James Gosling",
                    "124567", "http://www.java.com" });

            ContentItem javasong = new ContentItem(ContentType.Song
                , new string[] { "Java Movie", "James Gosling",
                    "124567", "http://www.javasong.com/mp3" });


            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(javaBook);
            catalog.Add(javasong);

            Assert.AreEqual(4, catalog.Count);
        }


        [TestMethod]
        [Timeout(500)]
        public void TestMethodAdd50000Items()
        {
            Catalog catalog = new Catalog();
            for (int i = 0; i < 10000; i++)
            {
                string[] cmdString = new string[] {"Intro C#" + i.ToString(), "S.Nakov", "12763892",
                "http://www.introprogramming.info"};
                ContentItem item = new ContentItem(ContentType.Book, cmdString);
                catalog.Add(item);
            }
            Assert.AreEqual(10000, catalog.Count);
        }

        [TestMethod]
        public void TestMethodGetListContentSingleItem()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem book = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[]{ "Intro Movie", "Author", "12456", "http://www.intromovie.com" });
            catalog.Add(movie);

            ContentItem app = new ContentItem(ContentType.Application,
                new string[] { "Intro App", "App Author", "12456", "http://www.intromovie.com" });
            catalog.Add(app);


            var result = catalog.GetListContent("Intro C#", 10);

            Assert.AreEqual(result.Count(), 1);
            Assert.AreSame(result.First(), book);
        }

        [TestMethod]
        public void TestMethodGetListContentMissingItem()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem book = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro Movie", "Author", "12456", "http://www.intromovie.com" });
            catalog.Add(movie);

            ContentItem app = new ContentItem(ContentType.Application,
                new string[] { "Intro App", "App Author", "12456", "http://www.intromovie.com" });
            catalog.Add(app);

            var result = catalog.GetListContent("Missing item", 10);

            Assert.AreEqual(result.Count(), 0);
        }

        [TestMethod]
        public void TestMethodGetListContentTwoMatchingItems()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem book = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(book);


            ContentItem app = new ContentItem(ContentType.Application,
                new string[] { "Intro App", "App Author", "12456", "http://www.intromovie.com" });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro C#", "Author", "12456", "http://www.intromovie.com" });
            catalog.Add(movie);


            var result = catalog.GetListContent("Intro C#", 10);

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void TestMethodGetListContentManyMatchingItemsGetFirstOnly()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem book = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(book);


            ContentItem app = new ContentItem(ContentType.Application,
                new string[] { "Intro app", "App Author", "12456", "http://www.intromovie.com" });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro C#", "Author", "12456", "http://www.intromovie.com" });
            catalog.Add(movie);


            var result = catalog.GetListContent("Intro C#", 1);

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void TestMethodGetListContentCheckOrder()
        {
            Catalog catalog = new Catalog();
            string[] cmdString = new string[] {"Intro C#", "S.Nakov", "12763892",
                "http://www.introprogramming.info"};

            ContentItem book = new ContentItem(ContentType.Book, cmdString);
            catalog.Add(book);


            ContentItem app = new ContentItem(ContentType.Application,
                new string[] { "Intro C#", "App Author", "12456", "http://www.intromovie.com" });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro C#", "Author", "12456", "http://www.intromovie.com" });
            catalog.Add(movie);


            ContentItem book2 = new ContentItem(ContentType.Book,
                 new string[] {"Intro C#", "Other Author", "12763892",
                "http://www.introprogramming.info"});
            catalog.Add(book2);

            var result = catalog.GetListContent("Intro C#", 10);

            Assert.AreEqual(result.Count(), 4);

            string[] expected = 
            { 
                @"Application: Intro C#; App Author; 12456; http://www.intromovie.com",
                "Book: Intro C#; Other Author; 12763892; http://www.introprogramming.info",
                "Book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info",
                "Movie: Intro C#; Author; 12456; http://www.intromovie.com"
            };
            string[] actual = new string[]
            {
                result.First().ToString(),
                result.Skip(1).First().ToString(),
                result.Skip(2).First().ToString(),
                result.Skip(3).First().ToString()
            };

            CollectionAssert.AreEqual(expected, actual);
        }        
    }
}
