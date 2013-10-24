using MVCApplication.Areas.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Areas.Products.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/Products/
        public ActionResult Index()
        {
            var prodcuts = ProductModel.GetProducts();

            return View(prodcuts);
        }

        public ActionResult Search(string name)
        {
            var prodcuts = ProductModel.GetProducts();
            var product = prodcuts.FirstOrDefault(x => x.Name == name);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
	}
}