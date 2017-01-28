using NUnit.Framework;
using Santase.Logic.Cards;
using Santase.Logic;
using System;


namespace GameEngine.Tests
{
    [TestFixture]
    public class DeckTests
    {
        public const int defaultDeckCards = 24;

        [Test]
        [Category("CheckTypes")]
        [TestCase(CardSuit.Club)]
        [TestCase(CardSuit.Diamond)]
        [TestCase(CardSuit.Heart)]
        [TestCase(CardSuit.Spade)]

        public void DeckIsTrumpCard_PartOfCardSuit(CardSuit suite)
        {
            Deck deck = new Deck();
            var card = deck.GetNextCard();
            bool res = false;
            if (card.Suit.GetType() == suite.GetType())
            {
                res = true;
            }
            Assert.IsTrue(res);

        }

        [Test]
        [Category("Deck")]
        public void Deck_WillThrownException_WhenLisfOfCardsIsEqualToZero()
        {
            Deck deck = new Deck();
            for (int i = 0; i < defaultDeckCards; i++)
            {
                deck.GetNextCard();
            }
            Assert.Throws<InternalGameException>(() => deck.GetNextCard());

        }

        [Test]
        [Category("Deck")]
        public void DeckCarsInDeckShouldBe24_WhenNewDeckIsIstanced()
        {
            Deck deck = new Deck();
            Assert.AreEqual(defaultDeckCards, deck.CardsLeft);
        }

        [Test]
        [TestCase(23,23)]
        [Category("BorderDeck")]
        public void DeckShoulHave23Cards_WhenOneIsDrawn(int cards,int remaining)
        {
            Deck deck = new Deck();
            deck.GetNextCard();
            Assert.AreEqual(cards, remaining);
        }

        [Test]
        [TestCase(1,1)]
        [Category("BorderDeck")]
        public void DeckShouldHave1CardRemaining_When23AreDrawn(int cards,int remaining)
        {
            Deck deck = new Deck();
            for (int i = 0; i < 23; i++)
            {
                deck.GetNextCard();
            }
            Assert.AreEqual(cards, remaining);
        }
        [Test]
        [Category("Deck")]
        [TestCase(CardSuit.Club,CardType.Ace)]
        [TestCase(CardSuit.Diamond,CardType.King)]
        public void DeckChangeTrump_WhenNewTrumIsPutted(CardSuit colour,CardType cardType)
        {
            //Arange
            Deck deck = new Deck();
            var card = new Card(colour, cardType);

            //Act
            deck.ChangeTrumpCard(card);

            //Assert
            Assert.AreEqual(card, deck.TrumpCard);

        }


        [Test]
        [Category("Change Trump")]
        [TestCase(CardSuit.Club, CardType.Ace)]
        [TestCase(CardSuit.Diamond, CardType.Jack)]
        [TestCase(CardSuit.Spade, CardType.King)]
        [TestCase(CardSuit.Spade, CardType.Queen)]
        [TestCase(CardSuit.Heart, CardType.Ten)]
        [TestCase(CardSuit.Diamond, CardType.Nine)]
        [TestCase(CardSuit.Club, CardType.Jack)]
        public void TestChangeWtihDifferentTrumps(CardSuit suit, CardType type)
        {
            Deck cards = new Deck();
            Card trump = new Card(suit, type);
            cards.ChangeTrumpCard(trump);

            Assert.AreEqual(trump.Type.ToFriendlyString() + trump.Suit.ToFriendlyString(), cards.TrumpCard.ToString());
        }


    }
}

