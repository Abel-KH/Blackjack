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
        public Player(string name)
        {
            Name = name;
            Balance = 100;
            Bet = 0;
            RoundsPlayed = 0;
        }
        public bool PlaceBet(int bet) //Kontrolerar och placerar spelarens insats
        {
            if (bet < 0 || bet > Balance)
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
    }
}
