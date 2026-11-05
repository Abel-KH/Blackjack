using BlackJackSpel;
using System;

public class Meny
{
    private bool programmetKor;
    private Highscore highscore = new Highscore();

    public Meny()
    {
        programmetKor = true;
    }
  
    public void Starta()
    {
        highscore.Load();
        while (programmetKor)
        {
            VisaMeny();
            int val = LasMenyval();
            HanteraVal(val);
        }
    }

    private void VisaMeny()
    {
        Console.WriteLine("=== Blackjack ===");
        Console.WriteLine("1. Play  2. Highscore  3. Rules  4. Exit");
        Console.Write("Choice: ");
    }

    private int LasMenyval()
    {
        string inmatning = Console.ReadLine();
        int val;

        if (int.TryParse(inmatning, out val))
        {
            if (val >= 1 && val <= 4)
            {
                return val;
            }
        }

        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
        Console.WriteLine();
        return 0;
    }

    private void HanteraVal(int val)
    {
        switch (val)
        {
            case 1:
                StartaSpel();
                break;
            case 2:
                VisaTopplista();
                break;
            case 3:
                VisaRegler();
                break;
            case 4:
                AvslutaProgram();
                break;
            default:

                break;
        }
    }


    private void StartaSpel()
    {
        string namn = LasNamn();

        BlackjackGame game = new BlackjackGame(namn);
        game.StartGame();

        if (game.GetRoundsPlayed() > 0)
        {
            highscore.Add(game.GetPlayerName(), game.GetBalance(), game.GetRoundsPlayed());
        }
    }

    private string LasNamn()
    {
        while (true)
        {
            Console.Write("Your name: ");
            string namn = Console.ReadLine();

            if (namn != null)
            {
                namn = namn.Trim();
                if (namn.Length > 0)
                {
                    return namn;
                }
            }

            Console.WriteLine("You must enter a name.");
        }
    }

    private void VisaTopplista()
    {
<<<<<<< Updated upstream
        highscore.Show();
        Console.WriteLine();
=======
      
        
>>>>>>> Stashed changes
    }

    private void VisaRegler()
    {
        Console.WriteLine();
        Console.WriteLine("Rules");
        Console.WriteLine("Get closer to 21 than the dealer without going over 21.");
        Console.WriteLine("Cards 2-10 are worth their face value. Jack, queen and king are worth 10.");
        Console.WriteLine("Ace is worth 11 or 1, whichever is better for the hand.");
        Console.WriteLine("Blackjack (ace + 10 on two cards) gives 1.5 times the bet, rounded down.");
        Console.WriteLine("The dealer stands on 17 or higher.");
        Console.WriteLine("You start with 100 kr. The minimum bet is 1 kr.");
        Console.WriteLine("Doubling, splitting and insurance are not included.");
        Console.WriteLine();
    }

    private void AvslutaProgram()
    {
        programmetKor = false;
        Console.WriteLine("Thank you for playing!");
    }
}