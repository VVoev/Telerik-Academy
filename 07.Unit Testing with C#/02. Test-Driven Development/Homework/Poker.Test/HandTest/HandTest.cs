using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Poker.Test.HandTest
{
    [TestFixture]
    public class HandTest
    {
        [Test]
        [Category("Hand")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]

        public void CheckHandsWorkCorrectlyWithDifferentValues(int numberOfCards)
        {
            IList<ICard> hands = new List<ICard>();
            var hand = new Hand(hands);
            for (int i = 0; i < numberOfCards; i++)
            {
                hands.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            }
            Assert.AreEqual(numberOfCards, hand.Cards.Count);
        }

        [Test]
        [Category("Hand")]
         public void HandShouldThrowExceptionWhenNullIsAdded()
        {
            IList<ICard> cards ;
            Assert.Throws<ArgumentNullException>(() => cards = new List<ICard>(null));
        }
        [Test]
        [Category("Hand")]
        [TestCase(CardFace.Ace, CardSuit.Clubs, CardFace.Four, CardSuit.Clubs, "Ace Clubs Four Clubs ")]
        [TestCase(CardFace.Two, CardSuit.Diamonds, CardFace.Three, CardSuit.Spades, "Two Diamonds Three Spades ")]
        [TestCase(CardFace.Five, CardSuit.Hearts, CardFace.Queen, CardSuit.Diamonds, "Five Hearts Queen Diamonds ")]
        public void HandReturnCorrectToString(CardFace firstF,CardSuit firstS,CardFace secondF,CardSuit secondS,string value)
        {
            var cards = new List<ICard>() { new Card(firstF, firstS), new Card(secondF, secondS) };
            var hand = new Hand(cards);

            var expected = value;

            Assert.AreEqual(expected, hand.ToString());
        }

   
    }
}
