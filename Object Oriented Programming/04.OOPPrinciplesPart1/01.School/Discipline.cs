using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Discipline : ICommentable
    {
        protected string name;
        protected int lecturesNumber;
        protected int exercisesNumber;
        protected string comments;

        public Discipline(string name, int lecturesNumber, int exercisesNumber)
        {
            this.name = name;
            this.lecturesNumber = lecturesNumber;
            this.exercisesNumber = exercisesNumber;
            this.comments = null;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int LecturesNumber
        {
            get { return this.lecturesNumber; }
        }

        public int ExercisesNumber
        {
            get { return this.exercisesNumber; }
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
