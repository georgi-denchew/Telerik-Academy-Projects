using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();
            string thirdLine = Console.ReadLine();

            char[,] field = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                field[0, i] = firstLine[i];
            }
            for (int i = 0; i < 3; i++)
            {
                field[1, i] = thirdLine[i];
            }
            for (int i = 0; i < 3; i++)
            {
                field[2, i] = thirdLine[i];
            }
        }
    }
}
