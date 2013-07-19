using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PrintingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints all the possible cards from a standart deck.");
            string[] cards = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] suits = { "Diamonds", "Spades", "Hearts", "Clubs" };
            foreach (string card in cards)
            {
                foreach (string suit in suits)
                {
                    Console.WriteLine("{0} of {1}", card, suit);
                }
            }
        }
    }
}
