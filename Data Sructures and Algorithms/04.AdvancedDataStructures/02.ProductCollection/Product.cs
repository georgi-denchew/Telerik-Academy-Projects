using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ProductCollection
{
    public class Product : IComparable
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }
        
        public double Price { get; private set; }


        #region IComparable Members

        public int CompareTo(object obj)
        {
            return this.Price.CompareTo((obj as Product).Price);
        }

        #endregion
    }
}
