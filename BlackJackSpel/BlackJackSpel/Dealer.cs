using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackSpel
{
    internal class Dealer
    {
        public List<Card> Cards { get; set; } //Antar att vi använder en Card-klass som representerar korten i spelet
        public Dealer()
        {
            Cards = new List<Card>();
        }
        public void AddCard(Card card) //Lägger till ett kort till dealerns hand
        {
            Cards.Add(card);
        }
        public int GetScore() //Beräknar dealerns poäng baserat på korten i handen
        {
            int score = 0;
            int aceCount = 0;
            foreach (Card card in Cards)
            {
                score += card.GetValue();
                if (card.Rank == "Ace")
                {
                    aceCount++;
                }
            }
            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }
            return score;
        }
        public bool ShouldDraw() //Kontrollerar om dealern ska dra ett kort baserat på poängen
        {
            return GetScore() < 17;
        }
        public void ClearHand() //Tömmer dealerns hand på kort
        {
            Cards.Clear();
        }
    }
}
