using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            string card1 = Console.ReadLine();
            string card2 = Console.ReadLine();
            string card3 = Console.ReadLine();
            string card4 = Console.ReadLine();
            string card5 = Console.ReadLine();
            int card1Int = int.Parse(card1);
            int card2Int = int.Parse(card2);
            int card3Int = int.Parse(card3);
            int card4Int = int.Parse(card4);
            int card5Int = int.Parse(card5);
            if ((card1 == "2" || card1 == "3" || card1 == "4" || card1 == "5" || card1 == "6" || card1 == "7" || card1 == "8" || card1 == "9" || card1 == "10" || card1 == "J" ||
                card1 == "Q" || card1 == "K" || card1 == "A") && (card2 == "2" || card2 == "3" || card2 == "4" || card2 == "5" || card2 == "6" || card2 == "7" || card2 == "8" ||
                card2 == "9" || card2 == "10" || card2 == "J" || card2 == "Q" || card2 == "K" || card2 == "A") && (card3 == "2" || card3 == "3" || card3 == "4" || card3 == "5" ||
                card3 == "6" || card3 == "7" || card3 == "8" || card3 == "9" || card3 == "10" || card3 == "J" || card3 == "Q" || card3 == "K" || card3 == "A") && (card4 == "2" ||
                card4 == "3" || card4 == "4" || card4 == "5" || card4 == "6" || card4 == "7" || card4 == "8" || card4 == "9" || card4 == "10" || card4 == "J" || card4 == "Q" ||
                card4 == "K" || card4 == "A") && (card5 == "2" || card5 == "3" || card5 == "4" || card5 == "5" || card5 == "6" || card5 == "7" || card5 == "8" || card5 == "9" ||
                card5 == "10" || card5 == "J" || card5 == "Q" || card5 == "K" || card5 == "A"))
            {
                if (card1 == card2 && card2 == card3 && card3 == card4 && card4 == card5)
                {
                    Console.WriteLine("Impossible");
                }

                else if ((card1 == card2 && card2 == card3 && card3 == card4 && card4 != card5) ||
                         (card1 == card2 && card2 == card3 && card3 == card5 && card5 != card4) ||
                         (card1 == card2 && card2 == card4 && card4 == card5 && card3 != card4) ||
                         (card1 == card3 && card3 == card4 && card4 == card5 && card2 != card4) ||
                         (card2 == card3 && card3 == card4 && card4 == card5 && card1 != card4))
                {
                    Console.WriteLine("Four of a Kind");
                }

                else if ((card1 == card2 && card2 == card3 && card3 != card4 && card4 != card5) ||
                         (card1 == card2 && card2 == card4 && card4 != card3 && card3 != card5) ||
                         (card1 == card3 && card3 == card4 && card4 != card2 && card2 != card5) ||
                         (card5 == card2 && card2 == card4 && card4 != card3 && card3 != card1) ||
                         (card5 == card3 && card3 == card4 && card4 != card2 && card2 != card1) ||
                         (card5 == card3 && card3 == card2 && card2 != card4 && card4 != card1) ||
                         (card1 == card2 && card2 == card5 && card3 != card5 && card4 != card3) ||
                         (card1 == card3 && card3 == card5 && card2 != card3 && card2 != card4) ||
                         (card1 == card4 && card4 == card5 && card2 != card5 && card2 != card3) ||
                         (card2 == card3 && card3 == card4 && card1 != card4 && card1 != card5))
                {
                    Console.WriteLine("Three of a Kind");
                }

                else if ((card1 == card2 && card2 == card3 && card3 != card4 && card4 == card5) ||
                         (card1 == card2 && card2 == card4 && card4 != card3 && card3 == card5) ||
                         (card1 == card3 && card3 == card4 && card4 != card2 && card2 == card5) ||
                         (card5 == card2 && card2 == card4 && card4 != card3 && card3 == card1) ||
                         (card5 == card3 && card3 == card4 && card4 != card2 && card2 == card1) ||
                         (card5 == card3 && card3 == card2 && card2 != card4 && card4 == card1) ||
                         (card1 == card2 && card2 == card5 && card3 != card5 && card4 == card3) ||
                         (card1 == card3 && card3 == card5 && card2 != card3 && card2 == card4) ||
                         (card1 == card4 && card4 == card5 && card2 != card5 && card2 == card3) ||
                         (card2 == card3 && card3 == card4 && card1 != card4 && card1 == card5))
                {
                    Console.WriteLine("Full House");
                }

                else if ((card1 == card2 && card2 != card3 && card3 != card4 && card4 == card5) ||
                         (card1 == card2 && card2 != card4 && card4 != card3 && card3 == card5) ||
                         (card1 == card3 && card3 != card4 && card4 != card2 && card2 == card5) ||
                         (card5 == card2 && card2 != card4 && card4 != card3 && card3 == card1) ||
                         (card5 == card3 && card3 != card4 && card4 != card2 && card2 == card1) ||
                         (card5 == card3 && card3 != card2 && card2 != card4 && card4 == card1) ||
                         (card1 == card2 && card2 != card5 && card3 != card5 && card4 == card3) ||
                         (card1 == card3 && card3 != card5 && card2 != card3 && card2 == card4) ||
                         (card1 == card4 && card4 != card5 && card2 != card5 && card2 == card3) ||
                         (card2 == card3 && card3 != card4 && card1 != card4 && card1 == card5) ||
                         (card1 == card3 && card3 != card2 && card2 != card4 && card4 == card5) ||
                         (card1 == card5 && card2 != card3 && card2 != card1 && card3 == card4))
                {
                    Console.WriteLine("Two Pairs");
                }
            }
        }
    }
}
