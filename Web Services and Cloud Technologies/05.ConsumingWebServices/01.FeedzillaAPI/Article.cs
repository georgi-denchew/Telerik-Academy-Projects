using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.FeedzillaAPI
{
    public class Article
    {
        public DateTime PublishDate { get; set; }

        public string Source { get; set; }

        public string SourceUrl { get; set; }

        public string Summary { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return string.Format("{0} Title: {1}; {0} URL: {2}", Environment.NewLine, this.Title, this.Url);
        }
    }
}
