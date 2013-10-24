using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.CarsForm
{
    public class Producer
    {
        public string Name { get; set; }

        public IEnumerable<string> Models { get; set; }
    }
}