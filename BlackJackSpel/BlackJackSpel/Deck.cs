using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackSpel
{
    internal class Deck
    {
        private List<Card> cards = new List<Card>();

        public Deck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            foreach (string suit in suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    cards.Add(new Card(suit, i));
                }

            }
        }

        //Drar ett slumpmässigt kort
        public Card DrawCard()
        {
            if (cards.Count == 0)
                return null;
            Random random = new Random();

            int index = random.Next(cards.Count);
            Card drawnCard = cards[index];
            cards.RemoveAt(index);
            return drawnCard;
        }
    }
}
