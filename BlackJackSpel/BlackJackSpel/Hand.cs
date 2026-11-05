using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BlackJackSpel
{
    internal class Hand
    {
        public List<Card> Cards { get; set; } //Antar att vi använder en Card-klass som representerar korten i spelet
        public Hand()
        {
            Cards = new List<Card>();
        }
        public void AddCard(Card card) //Lägger till ett kort till spelarens hand
        {
            Cards.Add(card);
        }
        public int GetScore() //Beräknar spelarens poäng baserat på korten i handen
        {
            int score = 0;
            int aceCount = 0;

            foreach (Card card in Cards)
            {
                score += card.GetValue();

                if (card.Value == 1)
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

        public bool HasBlackjack() //Kontrollerar om spelaren har blackjack (ess + 10 på två kort)
        {
            return Cards.Count == 2 && GetScore() == 21;
        }
        public bool IsBust() //Kontrollerar om spelaren har gått över 21
        {
            return GetScore() > 21;
        }
        public void ShowCards() //Visar spelarens hand på konsolen
        {
            Console.WriteLine("Din hand:");
            foreach (Card card in Cards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("Poäng: " + GetScore());
        }
        public void ClearHand() //Tömmer spelarens hand på kort
        {
            Cards.Clear();
        }
    }
}
