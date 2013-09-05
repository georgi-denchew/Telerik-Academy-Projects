using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsDb.Models
{
    public class School
    {
        public School()
        {
            this.Students = new HashSet<Student>();
        }

        public int ID { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public string Name { get; set; }
    }
}
