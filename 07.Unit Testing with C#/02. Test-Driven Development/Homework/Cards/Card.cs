using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override bool Equals(object otherCard)
        {
            var card = otherCard as Card;
            if(card== null)
            {
                return false;
            }
            return this.Face == card.Face && this.Suit == card.Suit;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Card is {this.Face}:{this.Suit}");
            return sb.ToString();
        }
    }
}
