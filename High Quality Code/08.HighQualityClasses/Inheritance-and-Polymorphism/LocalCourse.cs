using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : this(name, null, null, null)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }


        public string Lab
        {
            get 
            { 
                return this.lab; 
            }

            protected set 
            {
                this.lab = value; 
            }
        }

        /// <summary>
        /// Each lesson could be in a different lab, that's why
        /// the lab's name can be "changed" with a method
        /// </summary>
        /// <param name="labName"></param>
        public void AnnounceLab(string labName)
        {
            this.Lab = labName;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            base.AppendNameTeacherAndStudents();
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
