using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsDb.Models
{
    public class Mark
    {
        public int ID { get; set; }

        public string Subject { get; set; }

        public double Value { get; set; }

        public virtual Student Student { get; set; }
    }
}
