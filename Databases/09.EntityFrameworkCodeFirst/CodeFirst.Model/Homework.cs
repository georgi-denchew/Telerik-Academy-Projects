using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst.Model
{
    public class Homework
    {
        public Homework()
        {
        }

        public int ID { get; set; }

        public string Content { get; set; }

        // I think that's what "TimeSent" is supposed to mean
        public DateTime Deadline { get; set; }
    }
}
