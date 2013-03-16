using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Teacher : People, ICommentable
    {
        protected List<Discipline> disciplinesSet;
        protected string comments;

        public Teacher(string name, List<Discipline> disciplinesSet)
        {
            base.name = name;
            this.disciplinesSet = disciplinesSet;
            this.comments = null;
        }

        public List<Discipline> Disciplines
        {
            get { return this.disciplinesSet; }
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
