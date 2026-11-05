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
            ResetDeck();
        }

        private void ResetDeck()
        {
            cards.Clear();

            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

            foreach (string suit in suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    cards.Add(new Card(suit, i));
                }

            }

            Shuffle();

        }

        //Blandar kortleken
        public void Shuffle()
        {
            Random random = new Random();

            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        //Drar ett kort
        public Card DrawCard()
        {
            if (cards.Count < 15)
            {
                ResetDeck();
            }


            int index = cards.Count - 1;

            Card drawnCard = cards[index];
            cards.RemoveAt(index);

            return drawnCard;
        }
    }
}
