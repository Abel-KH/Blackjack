using System;

namespace BlackJackSpel
{
    internal class BlackjackGame
    {
        private Player player;
        private Dealer dealer;
        private Deck deck;
        public BlackjackGame(string playerName)
        {
            player = new Player(playerName);
            dealer = new Dealer();
            deck = new Deck();
        }
        public void StartGame()
        {
            Console.WriteLine($"Välkommen till Blackjack, {player.Name}!");
            while (player.Balance > 0)
            {
                Console.WriteLine($"Ditt Saldo: {player.Balance} kr");

                if (!PlaceBet())
                {
                    break;
                }
                StartRound();


                if (!player.HasBlackjack() && !dealer.HasBlackjack())
                {
                    PlayerTurn();
                }

                // Dealern drar kort endast om player inte har gått bust
                if (!player.IsBust())
                {
                    DealerTurn();
                }

                DetermineWinner();

                player.PlayRound();

                Console.WriteLine($"Ditt Nuvarande Saldo: {player.Balance} kr");

                if (player.Balance <= 0)
                {
                    Console.WriteLine("Du har slut på pengar! Spelet är över.");
                    break;
                }
                Console.Write("Vill du spela igen? (j/n): ");
                string playAgain = Console.ReadLine()?.ToLower();
                if (playAgain != "j")
                {
                    break;
                }
            }
            ShowFinalResult();
        }
        private bool PlaceBet()
        {
            while (true)
            {
                Console.Write("Ange din insats(0 för att avsluta): ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int bet))
                {
                    Console.WriteLine("Ogiltig insats. Försök igen.");
                    continue;
                }
                if (bet == 0)
                {
                    return false;
                }
                if (!player.PlaceBet(bet))
                {
                    Console.WriteLine("Insatsen är inte tillåten. Minsta insats är 1 kr och du kan inte satsa mer än ditt saldo.");
                    continue;
                }
                Console.WriteLine($"Du har satsat {bet} kr.");
                return true;
            }
        }

        private void StartRound() //Startar en ny spelrunda
        {
            player.ClearHand();
            dealer.ClearHand();
            deck.Shuffle();
            // Dela ut två kort till spelaren och dealern
            player.AddCard(deck.DrawCard());
            dealer.AddCard(deck.DrawCard());
            player.AddCard(deck.DrawCard());
            dealer.AddCard(deck.DrawCard());
            Console.WriteLine("Dina kort:");
            player.ShowCards();
            Console.WriteLine("Dealerns första kort:");
            Console.WriteLine(dealer.Hand.Cards[0]);
        }
        private void PlayerTurn() //Hantera spelarens tur
        {
            while (!player.IsBust())
            {
                Console.Write("Vill du dra ett kort (d) eller stanna (s)? ");
                string choice = Console.ReadLine()?.ToLower();
                if (choice == "d")
                {
                    Card card = deck.DrawCard();
                    player.AddCard(card);
                    Console.WriteLine($"Du drog: {card}");
                    player.ShowCards();
                    if (player.IsBust())
                    {
                        Console.WriteLine("Du har gått över 21! Du förlorar rundan.");
                        return;
                    }
                }
                else if (choice == "s")
                {
                    Console.WriteLine($"Du har valt att stanna på {player.GetScore()}.");
                    return;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }
        }
        private void DealerTurn() //Hantera dealerns tur
        {
            Console.WriteLine("Dealerns tur:");
            dealer.ShowCards();
            while (dealer.ShouldDraw())
            {
                Card card = deck.DrawCard();
                dealer.AddCard(card);
                Console.WriteLine($"Dealern drog: {card}");
                dealer.ShowCards();
            }
            Console.WriteLine($"Dealern stannar på {dealer.GetScore()}.");
        }
        private void DetermineWinner()
        {
            Console.WriteLine("Resultat:");
            Console.WriteLine($"Dina poäng: {player.GetScore()}");
            Console.WriteLine($"Dealerns poäng: {dealer.GetScore()}");
            if (player.IsBust())
            {
                Console.WriteLine("Du gick över 21! Du förlorar rundan.");
                player.LoseBet();
            }
            else if (dealer.IsBust())
            {
                Console.WriteLine("Dealern gick över 21! Du vinner rundan.");
                player.WinBet();
            }
            else if (player.HasBlackjack() && !dealer.HasBlackjack())
            {
                Console.WriteLine("Grattis! Du har Blackjack! Du vinner rundan.");
                player.WinBlackJack();
            }
            else if (!player.HasBlackjack() && dealer.HasBlackjack())
            {
                Console.WriteLine("Dealern har Blackjack! Du förlorar rundan.");
                player.LoseBet();
            }
            else if (player.GetScore() > dealer.GetScore())
            {
                Console.WriteLine("Du har högre poäng än dealern! Du vinner rundan.");
                player.WinBet();
            }
            else if (player.GetScore() < dealer.GetScore())
            {
                Console.WriteLine("Dealern har högre poäng än dig! Du förlorar rundan.");
                player.LoseBet();
            }
            else
            {
                Console.WriteLine("Oavgjort! Din insats återbetalas.");
                player.PushBet();
            }
        }
        private void ShowFinalResult() //Visar slutresultatet av spelet
        {
            Console.WriteLine();
            Console.WriteLine($"Spelare: {player.Name}");
            Console.WriteLine($"Ditt slutgiltiga saldo: {player.Balance} kr");
            Console.WriteLine($"Totalt antal rundor spelade: {player.RoundsPlayed}");
            Console.WriteLine("Tack för att du spelade!");
        }
    

    public string GetPlayerName()
        {
            return player.Name;
        }

        public int GetBalance()
        {
            return player.Balance;
        }

        public int GetRoundsPlayed()
        {
            return player.RoundsPlayed;
        }
    }
}
