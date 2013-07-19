using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Model
{
    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Homework> homeworks;

        private ICollection<string> materials;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
            this.materials = new HashSet<string>();

        }
        public int ID { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<string> Materials
        {
            get { return this.materials; }
            set { this.materials = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
