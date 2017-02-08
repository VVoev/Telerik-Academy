using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            if(cards== null)
            {
                throw new ArgumentNullException("List of cards cannot be null");
            }
            foreach (var item in cards)
            {
                if(item== null)
                {
                    throw new ArgumentNullException("You cannot added null card to all cards");
                }
            }
            this.Cards = cards;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in Cards)
            {
                sb.Append(string.Format($"{card.Face} {card.Suit} "));
            }

            return sb.ToString();
            
        }
    }
}
