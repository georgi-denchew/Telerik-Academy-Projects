using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.Articles
{
    public class Company
    {
        #region Constructors
        public Company()
            : this("No-name-company")
        {
        }

        public Company(string name)
        {
            this.Name = name;
            this.Articles = new OrderedMultiDictionary<double, Article>(true);
        } 
        #endregion

        #region Properties
        public OrderedMultiDictionary<double, Article> Articles { get; private set; }

        public string Name { get; private set; } 
        #endregion

        public void AddArtile(string barcode, string vendor, string title, double price)
        {
            this.Articles.Add(price, new Article(barcode, vendor, title, price));
        }

        public OrderedMultiDictionary<double, Article>.View ArticlesWithPrice(
            double from, bool fromInclusive, double to, bool toInclusive)
        {
            OrderedMultiDictionary<double, Article>.View articlesInRange = 
                this.Articles.Range(from, fromInclusive, to, toInclusive);

            return articlesInRange;
        }
    }
}
