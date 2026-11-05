using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackSpel
{
    internal class Dealer
    {
        public Hand Hand { get; set; }
        public Dealer()
        {
            Hand = new Hand();
        }
        public void AddCard(Card card) //Lägger till ett kort till dealerns hand
        {
            Hand.AddCard(card);
        }
        public int GetScore() //Beräknar dealerns poäng baserat på korten i handen
        {
            return Hand.GetScore();
        }
        public bool ShouldDraw() //Kontrollerar om dealern ska dra ett kort baserat på poängen
        {
            return GetScore() < 17;
        }
        public bool HasBlackjack() //Kontrollerar om dealern har blackjack (ess + 10 på två kort)
        {
            return Hand.HasBlackjack();
        }
        public bool IsBust() //Kontrollerar om dealern har gått över 21
        {
            return Hand.IsBust();
        }
        public void ShowCards() //Visar dealerns hand på konsolen
        {
            Hand.ShowCards();
        }
        public void ClearHand() //Tömmer dealerns hand på kort
        {
            Hand.ClearHand();
        }
    }
}
