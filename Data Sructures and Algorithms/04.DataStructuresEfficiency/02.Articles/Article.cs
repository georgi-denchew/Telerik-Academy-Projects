using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Articles
{
    public class Article : IComparable
    {
        #region Constructor
        
        public Article(string barcode, string vendor, string title, double price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        } 

        #endregion

        #region Properties
        
        public string Barcode { get; private set; }

        public string Vendor { get; private set; }

        public string Title { get; private set; }

        public double Price { get; private set; } 
        
        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return this.Price.CompareTo((obj as Article).Price);
        }

        #endregion
    }
}
