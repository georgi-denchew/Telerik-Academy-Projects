using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoMVCDemo.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Category()
        {
            this.Books = new HashSet<Book>();
        }
    }
}