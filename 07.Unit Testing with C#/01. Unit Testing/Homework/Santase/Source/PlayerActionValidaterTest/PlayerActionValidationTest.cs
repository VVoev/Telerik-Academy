using NUnit.Framework;
using System;
using Santase.Logic.PlayerActionValidate;
using Santase.Logic.Cards;
using System.Collections.Generic;

namespace PlayerActionValidaterTest
{
    [TestFixture]
    public class PlayerActionValidationTest
    {
        private static readonly Card JackOfHeart = new Card(CardSuit.Heart, CardType.Jack);

        private static readonly Card PlayerCard = new Card(CardSuit.Club, CardType.Jack);

        private static readonly Card NonExistingCard = new Card(CardSuit.Diamond, CardType.Ace);

        private static readonly ICollection<Card> PlayerCards = new List<Card>
                                                              {
                                                                  new Card(CardSuit.Spade, CardType.Nine),
                                                                  new Card(CardSuit.Heart,CardType.Jack),
                                                                  new Card(CardSuit.Diamond,CardType.Jack),
                                                                  new Card(CardSuit.Heart, CardType.King),
                                                                  new Card(CardSuit.Spade,CardType.Jack),
                                                                  new Card(CardSuit.Spade, CardType.Ace)
                                                              };
        [TestCase]
        public void CanPlayCardOnlyIFThePlayerIsFirst()
        {
            var canPlayCard = PlayCardActionValidator.CanPlayCard(false, JackOfHeart, PlayerCard, JackOfHeart, PlayerCards, true);

            Assert.IsFalse(canPlayCard);
        }

        [TestCase]
        public void CanPlayCardWhenPlayedCardAndTrumpCardAreEqual_PlayerIsNotFirstAndSuitsAreDifferent()
        {
            var canPlayCard = PlayCardActionValidator.CanPlayCard(false, JackOfHeart, PlayerCard, JackOfHeart, PlayerCards, true);

            Assert.IsTrue(canPlayCard);
        }

        [TestCase]
        public void CanNotPlayCard_IFPlayerHasSameSuitOfOtherPlayerPlayedCard()
        {
            Card JackOfDiamond = new Card(CardSuit.Diamond, CardType.Jack);
            Card QueenOfSpade = new Card(CardSuit.Spade, CardType.Queen);

            var canPlayCard = PlayCardActionValidator.CanPlayCard(false, JackOfDiamond, QueenOfSpade, JackOfDiamond, PlayerCards, true);

            Assert.IsFalse(canPlayCard);
        }
    }
}
