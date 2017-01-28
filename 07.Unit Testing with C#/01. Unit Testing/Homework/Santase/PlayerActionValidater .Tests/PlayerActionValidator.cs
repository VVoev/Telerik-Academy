namespace PlayerActionValidater.Tests
{
    using System;
    using NUnit.Framework;
    using Santase.Logic.PlayerActionValidate;
    using Santase.Logic.Cards;
    using System.Collections;
    using System.Collections.Generic;
    using Santase.Logic.Players;

    [TestFixture]
    public class PlayerActionValidatorzzz
    {
        private static readonly Card JackOfHeath = new Card(CardSuit.Heart, CardType.Jack);
        private static readonly Card PlayerCard = new Card(CardSuit.Club, CardType.King);
        private static readonly Card NotExistingCard = new Card(CardSuit.Spade, CardType.Ace);
        private static readonly ICollection<Card> PlayerCards = new List<Card>
                                                                 {
                                                                  new Card(CardSuit.Spade, CardType.Nine),
                                                                  new Card(CardSuit.Heart,CardType.Jack),
                                                                  new Card(CardSuit.Diamond,CardType.Jack),
                                                                  new Card(CardSuit.Heart, CardType.King),
                                                                  new Card(CardSuit.Spade,CardType.Jack),
                                                                  new Card(CardSuit.Spade, CardType.Ace)
                                                                 };


        
        [Category("Player Action Validator")]
        [TestCase]
        public void CanPlayOnlyIfThePlayerIsFirst()
        {
            var canPlayCard = PlayCardActionValidator.CanPlayCard(false, PlayerCard, JackOfHeath, JackOfHeath, PlayerCards, true);
            Assert.IsFalse(canPlayCard);
        }

        [TestCase]
        [Category("Player Action Validator")]
        public void CanPlayCardWhenPlayedCardAndTrumpCardAreEqual_PlayerIsNotFirstAndSuitsAreDifferent()
        {
            var canPlayCard = PlayCardActionValidator.CanPlayCard(false, JackOfHeath, PlayerCard, JackOfHeath, PlayerCards, true);

            Assert.IsTrue(canPlayCard);
        }

        [TestCase]
        [Category("Player Action Validator")]
        public void CanNotPlayCard_IFPlayerHasSameSuitOfOtherPlayerPlayedCard()
        {
            Card JackOfDiamond = new Card(CardSuit.Diamond, CardType.Jack);
            Card QueenOfSpade = new Card(CardSuit.Spade, CardType.Queen);

            var canPlayCard = PlayCardActionValidator.CanPlayCard(false, JackOfDiamond, QueenOfSpade, JackOfDiamond, PlayerCards, true);

            Assert.IsFalse(canPlayCard);
        }

    }
}
