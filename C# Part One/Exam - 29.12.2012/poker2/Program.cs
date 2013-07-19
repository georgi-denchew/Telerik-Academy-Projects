using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poker2
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
            if (card1 == "J")
            {
                card1 = "11";
            }
            if (card1 == "Q")
            {
                card1 = "12";
            }
            if (card1 == "K")
            {
                card1 = "13";
            }
            if (card1 == "A")
            {
                card1 = "14";
            }

            if (card2 == "J")
            {
                card2 = "11";
            }
            if (card2 == "Q")
            {
                card2 = "12";
            }
            if (card2 == "K")
            {
                card2 = "13";
            }
            if (card2 == "A")
            {
                card2 = "14";
            }
            if (card3 == "J")
            {
                card3 = "11";
            }
            if (card3 == "Q")
            {
                card3 = "12";
            }
            if (card3 == "K")
            {
                card3 = "13";
            }
            if (card3 == "A")
            {
                card3 = "14";
            }
            if (card4 == "J")
            {
                card4 = "11";
            }
            if (card4 == "Q")
            {
                card4 = "12";
            }
            if (card4 == "K")
            {
                card4 = "13";
            }
            if (card4 == "A")
            {
                card4 = "14";
            }
            if (card5 == "J")
            {
                card5 = "11";
            }
            if (card5 == "Q")
            {
                card5 = "12";
            }
            if (card5 == "K")
            {
                card5 = "13";
            }
            if (card5 == "A")
            {
                card5 = "14";
            }

            int cardint = 0;
            List<string> cards = new List<string>();
            int count = 0;
            int secondcount = 0;
            int thirdcount = 0;
            cards.Add(card1);
            cards.Add(card2);
            cards.Add(card3);
            cards.Add(card4);
            cards.Add(card5);
            if (int.Parse(card1) == int.Parse(card2) + 1 && int.Parse(card2) == int.Parse(card3) + 1 && int.Parse(card3) == int.Parse(card4) + 1 && int.Parse(card4) == int.Parse(card5) + 1)
            {
                Console.WriteLine("Straight");
            }
            for (int i = 2; i <= 14; i++)
            {
                count = 0;
                foreach (string card in cards)
                {
                    cardint = int.Parse(card);
                    if (cardint == i)
                    {
                        count++;
                    }
                }

                if (count == 5)
                {
                    Console.WriteLine("Impossible");
                    count = 0;
                }

                else if (count == 4)
                {
                    Console.WriteLine("Four of a Kind");
                    count = 0;
                }

                else if (count == 3)
                {
                    for (int j = 2; j <= 14; j++)
                    {
                        foreach (string card in cards)
                        {
                            cardint = int.Parse(card);
                            if (cardint == j && j != i)
                            {
                                secondcount++;
                            }

                            if (secondcount == 2)
                            {
                                break;
                            }

                        }
                    }
                    if (secondcount == 2)
                    {
                        Console.WriteLine("Full House");
                        break;
                    }
                    else
                    {

                        Console.WriteLine("Three of a kind");
                        break;
                    }
                }

                else if (count == 2)
                {
                    for (int j = 2; j <= 14; j++)
                    {
                        foreach (string card in cards)
                        {
                            cardint = int.Parse(card);
                            if (cardint == j && j != i)
                            {
                                thirdcount++;
                            }
                        }

                        if (thirdcount == 2)
                        {
                            break;
                        }
                        else
                        {
                            thirdcount = 0;
                        }
                    }
                    if (thirdcount == 2)
                    {
                        Console.WriteLine("Two Pairs");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("One Pair");
                    }
                }
            }
        }
    }
}