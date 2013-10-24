using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Areas.Products.Models
{
    public class ProductModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public static IList<ProductModel> GetProducts()
        {
            var products = new List<ProductModel>();

            products.Add(new ProductModel { Name = "Apple", Price = 1.4m });
            products.Add(new ProductModel { Name = "Banana", Price = 1.9m });
            products.Add(new ProductModel { Name = "Orange", Price = 1.2m });
            products.Add(new ProductModel { Name = "Lemon", Price = 1.6m });

            return products;
        }
    }
}