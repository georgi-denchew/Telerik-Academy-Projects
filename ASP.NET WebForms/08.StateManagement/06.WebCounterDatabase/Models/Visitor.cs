using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _06.WebCounterDatabase.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
