using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Poker.Test.PocherHandChecker
{
    [TestFixture]
    public class PockerHandsCheckerTest
    {   
        [Test]
        [Category("Pocker hands Checker")]
        public void ReturnTrueValidHand_WhenTrueValidHandIsUsed()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Spades),
                new Card(CardFace.Eight,CardSuit.Clubs)
            };

            var hand = new Hand(cards);
            checker.IsValidHand(hand);
        }

        [Test]
        [Category("Pocker hands Checker")]
        public void ShouldThrowEx_WhenNullCardIsAdded()
        {
            var checker = new PokerHandsChecker();
            IHand hand = null;

            Assert.Throws <ArgumentException>(() => checker.IsValidHand(hand));
        }

        [Test]
        [Category("Pocker hands Checker")]
        public void ShouldThrowException_WhenNumberOfCardsIsLessThanFive()
        {
            var checker = new PokerHandsChecker();
            var card = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs) };
            var hand = new Hand(card);
            Assert.Throws<ArgumentException>(() => checker.IsValidHand(hand));
        }

        [Test]
        [Category("Pocker hands Checker")]
        public void ShouldThrowException_WhenCardIsDublicated()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };
            var hand = new Hand(cards);
            checker.IsValidHand(hand);
        }


    }
}
