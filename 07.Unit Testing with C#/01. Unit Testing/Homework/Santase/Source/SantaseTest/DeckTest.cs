using NUnit.Framework;
using Santase.Logic;
using Santase.Logic.Cards;
using System;


namespace SantaseTest
{
    [TestFixture]
    public class DeckTest
    {
        [TestCase]
        public void CheckCardValueShouldReturnCorrectValue()
        {
            var card = new Card(CardSuit.Diamond, CardType.Jack);

            var cardNumber = (int)card.Type;

            Assert.Greater(12, cardNumber);
        }

        [TestCase]
        public void CheckCardSuitDiamondShouldReturnValueOne()
        {
            var card = new Card(CardSuit.Diamond, CardType.Jack);

            var cardSuit = (int)card.Suit;

            Assert.AreEqual(1, cardSuit);
        }

        [TestCase]
        public void GettingNextCardHalfTimesOfDeckCardsShouldReturn12()
        {
            var deck = new Deck();
            var startCardsCount = deck.CardsLeft;
            for (int i = 0; i < 12; i++)
            {
                deck.GetNextCard();
                startCardsCount = deck.CardsLeft;
            }

            Assert.AreEqual(12, startCardsCount);
        }

        [TestCase]
        public void CreatingNewDeckShouldReturn24()
        {
            var deck = new Deck();

            var startCardsCount = deck.CardsLeft;

            Assert.AreEqual(24, startCardsCount);
        }

        [TestCase]
        public void GettingNextCardMoreThan24TimesShouldThrowAnException()
        {
            var deck = new Deck();
            var startCardsCount = deck.CardsLeft;

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
                startCardsCount = deck.CardsLeft;
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [TestCase]
        public void ChangingTrumpCardShouldChangeCorrectly()
        {
            var deck = new Deck();

            var card = new Card(CardSuit.Club, CardType.Ace);

            deck.ChangeTrumpCard(card);

            Assert.AreEqual(card, deck.TrumpCard);
        }

        [TestCase]
        public void ChangingTrumpCardAfterGetting24CardsMustBeTrue()
        {
            var deck = new Deck();
            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }
            var cardToChange = new Card(CardSuit.Heart, CardType.Jack);

            deck.ChangeTrumpCard(cardToChange);

            Assert.AreEqual(cardToChange, deck.TrumpCard);
        }

        [TestCase(CardSuit.Club,CardType.Ace)]
        [TestCase(CardSuit.Diamond, CardType.Jack)]
        [TestCase(CardSuit.Spade, CardType.King)]
        [TestCase(CardSuit.Spade, CardType.Queen)]
        [TestCase(CardSuit.Heart, CardType.Ten)]
        [TestCase(CardSuit.Diamond, CardType.Nine)]
        [TestCase(CardSuit.Club, CardType.Jack)]
        public void TestChangeWtihDifferentTrumps(CardSuit suit,CardType type)
        {
            Deck cards = new Deck();
            Card trump = new Card(suit,type);
            cards.ChangeTrumpCard(trump);

            Assert.AreEqual(trump.Type.ToFriendlyString() + trump.Suit.ToFriendlyString(), cards.TrumpCard.ToString());
        }
    }
}
