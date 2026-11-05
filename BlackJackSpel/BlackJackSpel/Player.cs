using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackSpel
{
    internal class Player
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Bet { get; set; }
        public int RoundsPlayed { get; set; }
        public Hand Hand { get; set; }
        public Player(string name)
        {
            Name = name;
            Balance = 100;
            Bet = 0;
            RoundsPlayed = 0;
            Hand = new Hand();
        }
        public bool PlaceBet(int bet) //Kontrolerar och placerar spelarens insats
        {
            if (bet < 1 || bet > Balance)
            {
                return false;
            }
            Bet = bet;
            Balance -= bet;
            return true;
        }
        public void WinBet() //Uppdaterar spelarens balans när de vinner
        {
            Balance += Bet * 2;
            Bet = 0;
        }
        public void WinBlackJack() //Uppdaterar spelarens balans när de vinner med blackjack
        {
            Balance += (int)(Bet * 2.5);
            Bet = 0;
        }
        public void PushBet() //Uppdaterar spelarens balans när spelet blir oavgjort

        {
            Balance += Bet;
            Bet = 0;
        }
        public void LoseBet() //Uppdaterar spelarens balans när de förlorar
        {
            Bet = 0;
        }
        public void PlayRound() //Uppdaterar antalet rundor spelade
        {
            RoundsPlayed++;
        }
        public void AddCard(Card card) //Lägger till ett kort i spelarens hand
        {
            Hand.AddCard(card);
        }
        public int GetScore() //Beräknar spelarens poäng baserat på korten i handen
        {
            return Hand.GetScore();
        }
        public bool HasBlackjack() //Kontrollerar om spelaren har blackjack (ess + 10 på två kort)
        {
            return Hand.HasBlackjack();
        }
        public bool IsBust() //Kontrollerar om spelaren har gått över 21
        {
            return Hand.IsBust();
        }
        public void ShowCards() //Visar spelarens hand på konsolen
        {
            Hand.ShowCards();
        }
        public void ClearHand() //Tömmer spelarens hand på kort
        {
            Hand.ClearHand();
        }
    }
}
