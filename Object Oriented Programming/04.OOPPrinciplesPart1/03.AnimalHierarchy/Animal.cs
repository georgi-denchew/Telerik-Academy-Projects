using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    public abstract class Animal
    {
        protected string name;
        protected string sex;
        protected int age;

        public string Name
        {
            get { return this.name; }
        }

        public string Sex
        {
            get { return this.sex; }
        }

        public int Age
        {
            get { return this.age; }
        }
    }
}
