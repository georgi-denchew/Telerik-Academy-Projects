using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTests
{
    [TestClass]
    public class HandTests
    {
        Card card1 = new Card(CardFace.Jack, CardSuit.Clubs);
        Card card2 = new Card(CardFace.Five, CardSuit.Diamonds);
        Card card3 = new Card(CardFace.Nine, CardSuit.Hearts);
        Card card4 = new Card(CardFace.Six, CardSuit.Spades);
        Card card5 = new Card(CardFace.Three, CardSuit.Diamonds);
        Card card6 = new Card(CardFace.Eight, CardSuit.Hearts);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializingHandWithMoreThanMaximumCards()
        {
            IList<ICard> cardsList = new List<ICard>();
            cardsList.Add(card1);
            cardsList.Add(card2);
            cardsList.Add(card3);
            cardsList.Add(card4);
            cardsList.Add(card5);
            cardsList.Add(card6);

            Hand hand = new Hand(cardsList);
        }

        [TestMethod]
        public void TestingHandToStringMethod()
        {
            Hand hand = new Hand(card1, card2, card3, card4, card5);
            string handToString = card1.ToString() + ", " + card2.ToString() + ", " +
                card3.ToString() + ", " + card4.ToString() + ", " + card5.ToString();

            Assert.AreEqual(hand.ToString(), handToString);
        }
    }
}
