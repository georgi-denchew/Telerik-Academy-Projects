using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

struct Object
{
    public int x;
    public int y;
    public string str;
    public ConsoleColor color;

}

class Program
{
    static void PrintOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Blue)
{
    Console.SetCursorPosition(x, y);
    Console.ForegroundColor = color;
    Console.Write(str);
}
    static void Main(string[] args)
    {
        PrintOnPosition(5, 10, "Collect red L letters to recieve a bonus life", ConsoleColor.White);
        PrintOnPosition(5, 12, "Collect green S letters to recieve a bonus score of 200 points", ConsoleColor.White);
        PrintOnPosition(5, 14, "Avoid any other \"falling rocks\" to stay alive", ConsoleColor.White);
        PrintOnPosition(5, 16, "Press any key to start", ConsoleColor.White);
        Console.ReadKey();
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        int lifesCount = 5;
        int playfieldwidth = 25;
        Console.BufferHeight = Console.WindowHeight = 20;
        Console.BufferWidth = Console.WindowWidth = 50;
        Object dwarf1 = new Object();
        dwarf1.x = 19;
        dwarf1.y = Console.WindowHeight - 1;
        dwarf1.str = "(";
        dwarf1.color = ConsoleColor.White;
        Object dwarf2 = new Object();
        dwarf2.x = 21;
        dwarf2.y = Console.WindowHeight - 1;
        dwarf2.str = ")";
        dwarf2.color = ConsoleColor.White;
        Object dwarf0 = new Object();
        dwarf0.x = 20;
        dwarf0.y = Console.WindowHeight - 1;
        dwarf0.str = "0";
        dwarf0.color = ConsoleColor.White;
        List<Object> rocks = new List<Object>();
        Random randomGenerator = new Random();
        double score = 0;

        while (true)
        {
            score = score + 0.5;
            bool hit = false;
            {
                int chance = randomGenerator.Next(0, 100);
                if (chance < 5)
                {
                    Object BonusLife = new Object();
                    BonusLife.x = randomGenerator.Next(0, playfieldwidth);
                    BonusLife.color = ConsoleColor.Red;
                    BonusLife.y = 0;
                    BonusLife.str = "L";
                    rocks.Add(BonusLife);
                }
                else if (chance < 10)
                {
                    Object rockOne = new Object();
                    rockOne.x = randomGenerator.Next(0, playfieldwidth);
                    rockOne.color = ConsoleColor.Blue;
                    rockOne.y = 0;
                    rockOne.str = "^";
                    rocks.Add(rockOne);
                    Object rockOneA = new Object();
                    rockOneA.x = rockOne.x + 1;
                    rockOneA.color = ConsoleColor.Blue;
                    rockOneA.y = 0;
                    rockOneA.str = "^";
                    rocks.Add(rockOneA);
                    Object rockOneB = new Object();
                    rockOneB.x = rockOne.x + 2;
                    rockOneB.color = ConsoleColor.Blue;
                    rockOneB.y = 0;
                    rockOneB.str = "^";
                    rocks.Add(rockOneB);
                }
                else if (chance < 15)
                {
                    Object BonusScore = new Object();
                    BonusScore.x = randomGenerator.Next(0, playfieldwidth);
                    BonusScore.color = ConsoleColor.Green;
                    BonusScore.y = 0;
                    BonusScore.str = "S";
                    rocks.Add(BonusScore);
                }
                else if (chance < 20)
                {
                    Object rockTwo = new Object();
                    rockTwo.x = randomGenerator.Next(0, playfieldwidth);
                    rockTwo.color = ConsoleColor.Cyan;
                    rockTwo.y = 0;
                    rockTwo.str = "+";
                    rocks.Add(rockTwo);
                    Object rockTwoA = new Object();
                    rockTwoA.x = rockTwo.x + 1;
                    rockTwoA.color = ConsoleColor.Cyan;
                    rockTwoA.y = 0;
                    rockTwoA.str = "+";
                    rocks.Add(rockTwoA);
                    Object rockTwoB = new Object();
                    rockTwoB.x = rockTwo.x + 2;
                    rockTwoB.color = ConsoleColor.Cyan;
                    rockTwoB.y = 0;
                    rockTwoB.str = "+";
                    rocks.Add(rockTwoB);
                }
                else if (chance < 30)
                {
                    Object rockThree = new Object();
                    rockThree.x = randomGenerator.Next(0, playfieldwidth);
                    rockThree.color = ConsoleColor.Magenta;
                    rockThree.y = 0;
                    rockThree.str = "@";
                    rocks.Add(rockThree);
                    Object rockThreeA = new Object();
                    rockThreeA.x = rockThree.x + 1;
                    rockThreeA.color = ConsoleColor.Magenta;
                    rockThreeA.y = 0;
                    rockThreeA.str = "@";
                    rocks.Add(rockThreeA);
                }
                else if (chance < 40)
                {
                    Object rockFour = new Object();
                    rockFour.x = randomGenerator.Next(0, playfieldwidth);
                    rockFour.color = ConsoleColor.DarkYellow;
                    rockFour.y = 0;
                    rockFour.str = "*";
                    rocks.Add(rockFour);
                    Object rockFourA = new Object();
                    rockFourA.x = rockFour.x + 1;
                    rockFourA.color = ConsoleColor.DarkYellow;
                    rockFourA.y = 0;
                    rockFourA.str = "*";
                    rocks.Add(rockFourA);
                }
                else if (chance < 50)
                {
                    Object rockFive = new Object();
                    rockFive.x = randomGenerator.Next(0, playfieldwidth);
                    rockFive.color = ConsoleColor.Yellow;
                    rockFive.y = 0;
                    rockFive.str = "&";
                    rocks.Add(rockFive);
                }
                else if (chance < 60)
                {
                    Object rockSix = new Object();
                    rockSix.x = randomGenerator.Next(0, playfieldwidth);
                    rockSix.color = ConsoleColor.Gray;
                    rockSix.y = 0;
                    rockSix.str = "%";
                    rocks.Add(rockSix);
                }
                else if (chance < 70)
                {
                    Object rockSeven = new Object();
                    rockSeven.x = randomGenerator.Next(0, playfieldwidth);
                    rockSeven.color = ConsoleColor.Magenta;
                    rockSeven.y = 0;
                    rockSeven.str = "$";
                    rocks.Add(rockSeven);
                }
                else if (chance < 80)
                {
                    Object rockEight = new Object();
                    rockEight.x = randomGenerator.Next(0, playfieldwidth);
                    rockEight.color = ConsoleColor.DarkYellow;
                    rockEight.y = 0;
                    rockEight.str = "#";
                    rocks.Add(rockEight);
                }
                else if (chance < 90)
                {
                    Object rockNine = new Object();
                    rockNine.x = randomGenerator.Next(0, playfieldwidth);
                    rockNine.color = ConsoleColor.Gray;
                    rockNine.y = 0;
                    rockNine.str = "!";
                    rocks.Add(rockNine);
                }
                else if (chance < 95)
                {
                    Object rockTen = new Object();
                    rockTen.x = randomGenerator.Next(0, playfieldwidth);
                    rockTen.color = ConsoleColor.Cyan;
                    rockTen.y = 0;
                    rockTen.str = ".";
                    rocks.Add(rockTen);
                }
                else if (chance < 100)
                {
                    Object rockEleven = new Object();
                    rockEleven.x = randomGenerator.Next(0, playfieldwidth);
                    rockEleven.color = ConsoleColor.Gray;
                    rockEleven.y = 0;
                    rockEleven.str = ";";
                    rocks.Add(rockEleven);
                }
            }
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedkey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedkey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf1.x - 1 >= 0)
                    {
                        dwarf1.x--;
                        dwarf0.x--;
                        dwarf2.x--;
                    }
                }
                else if (pressedkey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf2.x + 1 < playfieldwidth)
                    {
                        dwarf2.x++;
                        dwarf1.x++;
                        dwarf0.x++;
                    }
                }
            }
            List<Object> newList = new List<Object>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Object oldRock = rocks[i];
                Object newRock = new Object();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.color = oldRock.color;
                newRock.str = oldRock.str;
                if (newRock.str == "L" && (newRock.x == dwarf0.x || newRock.x == dwarf1.x || newRock.x == dwarf2.x) && newRock.y == dwarf0.y)
                {
                    lifesCount++;
                }
                else if (newRock.str == "S" && (newRock.x == dwarf0.x || newRock.x == dwarf1.x || newRock.x == dwarf2.x) && newRock.y == dwarf0.y)
                {
                    score = score + 200;
                }
                else if ((newRock.x == dwarf0.x || newRock.x == dwarf1.x || newRock.x == dwarf2.x) && newRock.y == dwarf0.y)
                {
                    score = score - 50;
                    lifesCount--;
                    hit = true;
                    if (lifesCount < 0)
                    {
                        Console.Clear();
                        PrintOnPosition(10, 10, "GAME OVER!!", ConsoleColor.Red);
                        PrintOnPosition(10, 11, "Your final score is: " + score, ConsoleColor.Red);
                        PrintOnPosition(10, 12, "Press any key to exit.", ConsoleColor.Red);
                        Console.ReadKey();
                        return;
                    }
                }
                
                else if (newRock.y < Console.WindowHeight)
                {
                    newList.Add(newRock);
                }
            }
            rocks = newList;
            Console.Clear();
            foreach (Object rock in rocks)
            {
                PrintOnPosition(rock.x, rock.y, rock.str, rock.color);
            }
            if (hit)
            {
                rocks.Clear();
                PrintOnPosition(dwarf0.x, dwarf0.y, "X", ConsoleColor.Red);
                PrintOnPosition(dwarf2.x, dwarf2.y, "X", ConsoleColor.Red);
                PrintOnPosition(dwarf1.x, dwarf1.y, "X", ConsoleColor.Red);
            }
            else
            {
                PrintOnPosition(dwarf1.x, dwarf1.y, dwarf1.str, dwarf1.color);
                PrintOnPosition(dwarf2.x, dwarf2.y, dwarf2.str, dwarf2.color);
                PrintOnPosition(dwarf0.x, dwarf0.y, dwarf0.str, dwarf0.color);
            }
            PrintOnPosition(32, 10, "Lifes: " + lifesCount, ConsoleColor.White);
            PrintOnPosition(32, 11, "Score: " + score, ConsoleColor.White);
            Thread.Sleep(100);
        }
    }
}