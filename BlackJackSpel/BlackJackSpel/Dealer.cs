namespace BlackJackSpel
{
    internal class Dealer
    {
        public Hand hand { get; set; } // En Hand-klass som representerar dealerns hand
        public Dealer()
        {
            hand = new Hand();
        }
        public void AddCard(Card card) //Lägger till ett kort till dealerns hand
        {
            hand.AddCard(card);
        }
        public int GetScore() //Beräknar dealerns poäng baserat på korten i handen
        {

            return hand.GetScore();
        }
        public bool ShouldDraw() //Kontrollerar om dealern ska dra ett kort baserat på poängen
        {
            return hand.GetScore() < 17;
        }
        public bool HasBlackjack() //Kontrollerar om dealern har blackjack (ess + 10 på två kort)
        {
            return hand.HasBlackjack();
        }
        public bool IsBust() //Kontrollerar om dealern har gått över 21
        {
            return hand.IsBust();
        }
        public void ShowCards() //Visar dealerns hand på konsolen
        {
            hand.ShowCards();
        }
        public void ClearHand() //Tömmer dealerns hand på kort
        {
            hand.ClearHand();
        }
    }
}
