using System;
using _01.ChefClass;

namespace _02.RefactoringIfStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            Chef chef = new Chef();
            Potato potato = new Potato(3);

            if (potato == null)
            {
                throw new MissingMemberException("No potato found! :)");
            }

            else if(potato.IsPeeled && potato.IsFresh)
            {
                chef.Cook();
            }

            //------------------------------------

            int x = 3;
            int X_MAX_VALUE = 1;
            int X_MIN_VALUE = 4;
            bool xInRange = x >= X_MIN_VALUE && x <= X_MAX_VALUE;

            int y = 2;
            int Y_MIN_VALUE = 0;
            int Y_MAX_VALUE = 5;
            bool yInRange = y >= Y_MIN_VALUE && y <= Y_MAX_VALUE;
            
            bool cellVisitAllowed = xInRange && yInRange;

            if (cellVisitAllowed)
            {
                VisitCell();
            }
        }

        public static void VisitCell()
        {
        }
    }
}