using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class School
    {
        private string name;
        private List<Class> classes;

        public School(string name, List<Class> classes)
        {
            this.name = name;
            this.classes = classes;
        }

        public string Name
        {
            get { return this.name; }
        }

        public List<Class> Classes
        {
            get { return this.classes; }
        }
    }
}
