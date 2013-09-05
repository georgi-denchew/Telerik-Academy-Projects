using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.FeedzillaAPI
{
    public class ArticlesCollection
    {
        public HashSet<Article> articles { get; set; }

        public ArticlesCollection()
        {
            this.articles = new HashSet<Article>();
        }

        public string Description { get; set; }

        public string Title { get; set; }

        public string SyndicationUrl { get; set; }

    }
}
