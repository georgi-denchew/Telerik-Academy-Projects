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

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this == null)
            {
                return result.ToString();
            }

            result.AppendFormat("The {0} of {1}", this.Face, this.Suit);
            return result.ToString();
        }
    }
}
