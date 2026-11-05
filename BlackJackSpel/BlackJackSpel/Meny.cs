using System;
using BlackJackSpel;

public class Meny
{
    private bool programmetKor;

    public Meny()
    {
        programmetKor = true;
    }

    public void Starta()
    {
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
        Console.WriteLine("1. Spela  2. Topplista  3. Regler  4. Avsluta");
        Console.Write("Val: ");
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

        Console.WriteLine("Ogiltigt val. Skriv en siffra mellan 1 och 4.");
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
    }

    private string LasNamn()
    {
        while (true)
        {
            Console.Write("Ditt namn: ");
            string namn = Console.ReadLine();

            if (namn != null)
            {
                namn = namn.Trim();
                if (namn.Length > 0)
                {
                    return namn;
                }
            }

            Console.WriteLine("Du måste skriva ett namn.");
        }
    }

    private void VisaTopplista()
    {
      
        Console.WriteLine();
        Console.WriteLine("Topplistan är inte inkopplad ännu.");
        Console.WriteLine("Den som gör JSON/topplista lägger sitt anrop här i VisaTopplista().");
        Console.WriteLine();
    }

    private void VisaRegler()
    {
        Console.WriteLine();
        Console.WriteLine("Regler");
        Console.WriteLine("Kom närmare 21 än dealern utan att gå över 21.");
        Console.WriteLine("Kort 2-10 är värda sin siffra. Knekt, dam och kung är värda 10.");
        Console.WriteLine("Ess är värt 11 eller 1, det som är bäst för handen.");
        Console.WriteLine("Blackjack (ess + 10 på två kort) ger 1,5 gånger insatsen, avrundat nedåt.");
        Console.WriteLine("Dealern stannar på 17 eller mer.");
        Console.WriteLine("Du börjar med 100 kr. Minsta insats är 1 kr.");
        Console.WriteLine("Dubbla, dela och försäkring ingår inte.");
        Console.WriteLine();
    }

    private void AvslutaProgram()
    {
        programmetKor = false;
        Console.WriteLine("Tack för att du spelade!");
    }
}