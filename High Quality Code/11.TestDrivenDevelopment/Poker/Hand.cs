namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            if (cards.Count > 5)
            {
                throw new ArgumentOutOfRangeException("A hand cannot consist of more than five cards");
            }

            this.Cards = cards;
        }

        public Hand(Card card1, Card card2, Card card3, Card card4, Card card5)
        {
            this.Cards = new List<ICard>();
            this.Cards.Add(card1);
            this.Cards.Add(card2);
            this.Cards.Add(card3);
            this.Cards.Add(card4);
            this.Cards.Add(card5);            
        }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Card card in this.Cards)
            {
                if (card != null)
                {
                    result.Append(card.ToString());
                    result.Append(", ");
                }
            }

            result.Remove(result.Length - 2, 2);
            return result.ToString();
        }
    }
}
