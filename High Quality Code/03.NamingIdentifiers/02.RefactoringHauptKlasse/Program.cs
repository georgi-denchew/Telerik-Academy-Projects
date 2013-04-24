using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RefactoringHauptKlasse
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human();
            human.CreateHuman(24);

            Console.WriteLine(human);
        }
    }
}
