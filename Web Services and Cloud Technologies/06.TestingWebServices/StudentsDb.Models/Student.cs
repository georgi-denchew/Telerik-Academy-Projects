using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDb.Models
{
    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public virtual School School { get; set; }
    }
}
