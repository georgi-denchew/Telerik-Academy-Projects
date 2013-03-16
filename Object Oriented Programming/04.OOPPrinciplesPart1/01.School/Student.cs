using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Student : People, ICommentable
    {
        protected int classNumber;
        protected string comments;

        public Student(string name, int classNumber)
        {
            base.name = name;
            this.classNumber = classNumber;
            this.comments = null;
        }

        public int ClassNumber
        {
            get { return this.classNumber; }
        }

        public string Comments
        {
            get { return this.comments; }
        }

        public void AddComment(string comment)
        {
            if (this.comments == null)
            {
                this.comments = comment;
            }
            else
            {
                this.comments += "\r\n" + comment;
            }
        }

    }
}
