using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestingCardToStringMethod()
        {
            Card aceOfClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card twoOfDiamonds = new Card(CardFace.Two, CardSuit.Diamonds);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);
            Card jackOfSpades = new Card(CardFace.Jack, CardSuit.Spades);

            Assert.AreEqual(CardFace.Ace, aceOfClubs.Face);
            Assert.AreEqual(CardSuit.Clubs, aceOfClubs.Suit);
            Assert.AreEqual(CardFace.Two, twoOfDiamonds.Face);
            Assert.AreEqual(CardSuit.Diamonds, twoOfDiamonds.Suit);
            Assert.AreEqual(CardFace.Ten, tenOfHearts.Face);
            Assert.AreEqual(CardSuit.Hearts, tenOfHearts.Suit);
            Assert.AreEqual(CardFace.Jack, jackOfSpades.Face);
            Assert.AreEqual(CardSuit.Spades, jackOfSpades.Suit);
        }
    }
}