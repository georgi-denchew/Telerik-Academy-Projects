using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (hand.Cards[i].Suit == hand.Cards[j].Suit &&
                        hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsFlush(hand) && IsStraight(hand))
            {
                return true;
            }

            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (CardFaceWithMostOccurences(hand).Value == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (CardFaceWithMostOccurences(hand).Value == 3)
            {
                var exceptFace = CardFaceWithMostOccurences(hand).Key;

                if (CardFaceWithMostOccurences(hand, exceptFace).Value == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            bool isFlush = (hand.Cards[0].Suit == hand.Cards[1].Suit) &&
                (hand.Cards[0].Suit == hand.Cards[2].Suit) && (hand.Cards[0].Suit == hand.Cards[3].Suit) &&
                (hand.Cards[0].Suit == hand.Cards[4].Suit);

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            List<int> values = new List<int>();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                values.Add((int)hand.Cards[i].Face);
            }

            values.Sort();

            if (values[0] == 2 && values[1] == 3 && values[2] == 4 &&
                values[3] == 5 && values[4] == 14)
            {
                return true;
            }

            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] - 1 != values[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (!IsFourOfAKind(hand) && CardFaceWithMostOccurences(hand).Value == 3)
            {
                return true;
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (CardFaceWithMostOccurences(hand).Value == 2)
            {
                var exceptFace = CardFaceWithMostOccurences(hand).Key;

                if (CardFaceWithMostOccurences(hand, exceptFace).Value == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand) || IsTwoPair(hand))
            {
                return false;
            }

            if (CardFaceWithMostOccurences(hand).Value == 2)
            {
                return true;
            }

            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (CardFaceWithMostOccurences(hand).Value == 1)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Performing checks to determine the first hand
        /// and after that checks if the second hand is higher
        /// </summary>
        /// <param name="firstHand"></param>
        /// <param name="secondHand"></param>
        /// <returns></returns>
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (IsStraightFlush(firstHand))
            {
                if (IsStraightFlush(secondHand))
                {
                    return CompareHighestCards(firstHand, secondHand);
                }
                else
                {
                    return 1;
                }
            }
            else if (IsFourOfAKind(firstHand))
            {
                if (IsStraightFlush(secondHand))
                {
                    return -1;
                }
                else if (IsFourOfAKind(secondHand))
                {
                    return CardFaceWithMostOccurences(firstHand).Key.CompareTo
                        (CardFaceWithMostOccurences(secondHand).Key);
                }
                else
                {
                    return 1;
                }
            }
            else if (IsFullHouse(firstHand))
            {
                if (IsStraightFlush(secondHand) || IsFourOfAKind(secondHand))
                {
                    return -1;
                }
                else if (IsFullHouse(secondHand))
                {
                    return CardFaceWithMostOccurences(firstHand).Key.CompareTo
                        (CardFaceWithMostOccurences(secondHand).Key);
                }
                else
                {
                    return 1;
                }
            }
            else if (IsFlush(firstHand))
            {
                if (IsStraightFlush(secondHand) || IsFourOfAKind(secondHand) ||
                    IsFullHouse(secondHand))
                {
                    return -1;
                }
                else if (IsFlush(secondHand))
                {
                    return CardFaceWithMostOccurences(firstHand).Key.CompareTo
                        (CardFaceWithMostOccurences(secondHand).Key);
                }
                else
                {
                    return 1;
                }
            }
            else if (IsStraight(firstHand))
            {
                if (IsStraightFlush(secondHand) || IsFourOfAKind(secondHand) ||
                    IsFullHouse(secondHand) || IsFlush(secondHand))
                {
                    return -1;
                }
                else if (IsStraight(secondHand))
                {
                    return CardFaceWithMostOccurences(firstHand).Key.CompareTo
                       (CardFaceWithMostOccurences(secondHand).Key);
                }
                else
                {
                    return 1;
                }
            }
            else if (IsThreeOfAKind(firstHand))
            {
                if (IsStraightFlush(secondHand) || IsFourOfAKind(secondHand) ||
                    IsFullHouse(secondHand) || IsFlush(secondHand) || IsStraight(secondHand))
                {
                    return -1;
                }
                else if (IsThreeOfAKind(secondHand))
                {
                    return CardFaceWithMostOccurences(firstHand).Key.CompareTo
                       (CardFaceWithMostOccurences(secondHand).Key);
                }
                else
                {
                    return 1;
                }
            }
            else if (IsTwoPair(firstHand))
            {
                if (IsOnePair(secondHand) || IsHighCard(secondHand))
                {
                    return 1;
                }
                else if (IsTwoPair(secondHand))
                {
                    return CardFaceWithMostOccurences(firstHand).Key.CompareTo
                       (CardFaceWithMostOccurences(secondHand).Key);
                }
                else
                {
                    return -1;
                }
            }
            else if (IsOnePair(firstHand))
            {
                if (IsHighCard(secondHand))
                {
                    return 1;
                }
                else if (IsOnePair(secondHand))
                {
                    return CardFaceWithMostOccurences(firstHand).Key.CompareTo
                       (CardFaceWithMostOccurences(secondHand).Key);
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (IsHighCard(secondHand))
                {
                    
                    return CardFaceWithMostOccurences(firstHand).Key.CompareTo
                       (CardFaceWithMostOccurences(secondHand).Key);
                }
                else
                {
                    return -1;
                }
            }

        }

        private int CompareHighestCards(IHand firstHand, IHand secondHand)
        {
            if (GetHighestCardValue(firstHand) > GetHighestCardValue(secondHand))
            {
                return 1;
            }
            else if (GetHighestCardValue(firstHand) == GetHighestCardValue(secondHand))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        private int GetHighestCardValue(IHand hand)
        {
            int maxValue = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (maxValue < (int)hand.Cards[i].Face)
                {
                    maxValue = (int)hand.Cards[i].Face;
                }
            }

            return maxValue;
        }

        /// <summary>
        /// Returns the a pair of consisting of the most frequent cardface
        /// in the hand and the number of times it occurs in the hand.
        /// </summary>
        /// <param name="hand">The hand to be checked</param>
        /// <returns></returns>
        private KeyValuePair<CardFace, int> CardFaceWithMostOccurences(IHand hand)
        {
            int currentFacesCount = 1;
            int maxFacesCount = 1;

            var face = CardFace.Eight;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        currentFacesCount++;
                    }

                    if (currentFacesCount > maxFacesCount)
                    {
                        maxFacesCount = currentFacesCount;
                        face = hand.Cards[i].Face;
                    }
                }
                currentFacesCount = 1;
            }
            return new KeyValuePair<CardFace, int>(face, maxFacesCount);
        }

        /// <summary>
        ///  Returns the a pair of consisting of the most frequent cardface
        /// in the hand and the number of times it occurs in the hand.
        /// </summary>
        /// <param name="hand">The hand to be checked</param>
        /// <param name="exceptFace">Optional: face that shouldn't be checked</param>
        /// <returns></returns>
        private KeyValuePair<CardFace, int> CardFaceWithMostOccurences(IHand hand, CardFace exceptFace)
        {
            int currentFacesCount = 1;
            int maxFacesCount = 1;
            var face = CardFace.Ace;


            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Face != exceptFace)
                {
                    for (int j = 0; j < hand.Cards.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        else if (hand.Cards[i].Face == hand.Cards[j].Face)
                        {
                            currentFacesCount++;
                        }

                        if (currentFacesCount > maxFacesCount)
                        {
                            face = hand.Cards[i].Face;
                            maxFacesCount = currentFacesCount;
                        }
                    }
                }
                currentFacesCount = 1;
            }

            return new KeyValuePair<CardFace, int>(face, maxFacesCount);
        }
    }
}
