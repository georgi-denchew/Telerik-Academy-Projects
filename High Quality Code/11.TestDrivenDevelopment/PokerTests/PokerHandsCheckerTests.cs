using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        PokerHandsChecker checker = new PokerHandsChecker();
        
        Hand flushHand = new Hand(new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Jack, CardSuit.Clubs));
        
        Hand fourOfAKindHand = new Hand(new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.King, CardSuit.Diamonds), new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.Jack, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Spades));
        
        Hand fiveKings = new Hand(new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.King, CardSuit.Diamonds), new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Spades));

        Hand highCardHand = new Hand(new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Spades), new Card(CardFace.Six, CardSuit.Hearts));

        Hand onePairHand = new Hand(new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Hearts));

        Hand twoPairHand = new Hand(new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.Four, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Hearts));

        Hand threeOfAKindHand = new Hand(new Card(CardFace.Five, CardSuit.Clubs),
           new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts),
           new Card(CardFace.Three, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Hearts));

        Hand fullHouseHand = new Hand(new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Diamonds), new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.Jack, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Spades));

        Hand firstStraightHand = new Hand(new Card(CardFace.Four, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Hearts));

        Hand secondStraightHand = new Hand(new Card(CardFace.Ten, CardSuit.Spades),
           new Card(CardFace.Jack, CardSuit.Hearts), new Card(CardFace.Queen, CardSuit.Clubs),
           new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Hearts));

        Hand straightFlushHand = new Hand(new Card(CardFace.Ten, CardSuit.Spades),
           new Card(CardFace.Jack, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Spades),
           new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades));


        // Task 03
        [TestMethod]
        public void TestingIsValidHandMethod()
        {
            Assert.IsTrue(checker.IsValidHand(fourOfAKindHand));
            Assert.IsFalse(checker.IsValidHand(fiveKings));
        }

        // Task 04
        [TestMethod]
        public void TestingIsFlushMethod()
        {
            Assert.IsTrue(checker.IsFlush(flushHand));
        }

        // Task 05
        [TestMethod]
        public void TestingIsFourOfAKindMethod()
        {
            Assert.IsFalse(checker.IsFourOfAKind(secondStraightHand));
            Assert.IsTrue(checker.IsFourOfAKind(fourOfAKindHand));
        }

        // Task 06
        [TestMethod]
        public void TestIsHighCardMethod()
        {
            Assert.IsTrue(checker.IsHighCard(highCardHand));
        }

        // Task 06
        [TestMethod]
        public void TestIsOnePairMethod()
        {
            Assert.IsTrue(checker.IsOnePair(onePairHand));
        }

        // Task 06
        [TestMethod]
        public void TestIsTwoPairMethod()
        {
            Assert.IsTrue(checker.IsTwoPair(twoPairHand));
        }

        // Task 06
        [TestMethod]
        public void TestIsThreeOfAKindMethod()
        {
            Assert.IsTrue(checker.IsThreeOfAKind(threeOfAKindHand));
        }

        // Task 06
        [TestMethod]
        public void TestIsFullHouseMethod()
        {
            Assert.IsTrue(checker.IsFullHouse(fullHouseHand));
        }

        // Task 06
        [TestMethod]
        public void TestIsStraightMethod()
        {
            Assert.IsTrue(checker.IsStraight(firstStraightHand));
            Assert.IsTrue(checker.IsStraight(secondStraightHand));
        }

        // Task 06
        [TestMethod]
        public void TestIsStraightFlushMethod()
        {
            Assert.IsTrue(checker.IsStraightFlush(straightFlushHand));
        }

        // Task 07
        [TestMethod]
        public void TestCompareHandsMethod()
        {
            Assert.AreEqual(1, checker.CompareHands(straightFlushHand, fourOfAKindHand));
            Assert.AreEqual(1, checker.CompareHands(fourOfAKindHand, fullHouseHand));
            Assert.AreEqual(1, checker.CompareHands(fullHouseHand, flushHand));
            Assert.AreEqual(1, checker.CompareHands(flushHand, firstStraightHand));
            Assert.AreEqual(1, checker.CompareHands(firstStraightHand, threeOfAKindHand));
            Assert.AreEqual(1, checker.CompareHands(threeOfAKindHand, twoPairHand));
            Assert.AreEqual(1, checker.CompareHands(twoPairHand, onePairHand));
            Assert.AreEqual(1, checker.CompareHands(onePairHand, highCardHand));
            Assert.AreEqual(0, checker.CompareHands(highCardHand, highCardHand));

            Assert.AreEqual(0, checker.CompareHands(straightFlushHand, straightFlushHand));
            Assert.AreEqual(0, checker.CompareHands(fourOfAKindHand, fourOfAKindHand));
            Assert.AreEqual(0, checker.CompareHands(fullHouseHand, fullHouseHand));
            Assert.AreEqual(0, checker.CompareHands(flushHand, flushHand));
            Assert.AreEqual(0, checker.CompareHands(firstStraightHand, firstStraightHand));
            Assert.AreEqual(0, checker.CompareHands(threeOfAKindHand, threeOfAKindHand));
            Assert.AreEqual(0, checker.CompareHands(twoPairHand, twoPairHand));
            Assert.AreEqual(0, checker.CompareHands(onePairHand, onePairHand));
        }
    }
}
