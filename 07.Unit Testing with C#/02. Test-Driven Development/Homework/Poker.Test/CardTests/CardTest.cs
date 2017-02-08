using NUnit.Framework;
using System;

namespace Poker.Test.CardTests
{
    [TestFixture]
    class CardTest
    {
        [Category("Card")]
        [Test]
        [TestCase(CardFace.Ace,CardSuit.Clubs)]
        [TestCase(CardFace.Two,CardSuit.Spades)]
        [TestCase(CardFace.Five, CardSuit.Hearts)]
        [TestCase(CardFace.Nine, CardSuit.Diamonds)]
        public void TestingCardCtor_WhenProvidedCardsAreValid(CardFace face,CardSuit suit)
        {
            var cardOne = new Card(face, suit);
            var cardTwo = new Card(face, suit);

            Assert.AreEqual(cardOne.ToString(), cardTwo.ToString());
        }

        [Category("Card")]
        [Test]
        [TestCase(CardFace.Ace, CardSuit.Clubs,CardFace.King,CardSuit.Clubs)]
        [TestCase(CardFace.Ace, CardSuit.Clubs,CardFace.Ace,CardSuit.Hearts)]
        [TestCase(CardFace.Two, CardSuit.Diamonds,CardFace.Two,CardSuit.Hearts)]
        [TestCase(CardFace.Ace, CardSuit.Clubs,CardFace.Ace,CardSuit.Hearts)]
        public void CardShouldCompareCardsCorretly_WhenCardsAreDifferent(CardFace cardOneFace,CardSuit cardOneSuit, CardFace cardTwoFace,CardSuit cardTwoSuit)
        {
            var firstCard = new Card(cardOneFace, cardOneSuit);
            var secondCard = new Card(cardTwoFace, cardTwoSuit);

            Assert.IsFalse(firstCard.Equals(secondCard));
        }

        [Category("Card")]
        [Test]
        [TestCase(CardFace.Ace,CardSuit.Clubs,"Card is Ace:Clubs")]
        [TestCase(CardFace.Two, CardSuit.Clubs, "Card is Two:Clubs")]
        [TestCase(CardFace.Five, CardSuit.Diamonds, "Card is Five:Diamonds")]
        [TestCase(CardFace.Queen, CardSuit.Hearts, "Card is Queen:Hearts")]

        public void ToStringShouldWorkCorrectly_WhenCompareWithActualCard(CardFace face,CardSuit suit,string value)
        {
            var card = new Card(face, suit);

            Assert.AreEqual(card.ToString(), value);
        }


    }
}
