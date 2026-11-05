using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackSpel
{
    internal class Card
    {
        public string Suit { get; set; }
        public int Value { get; set; }
        public Card(string suit, int value)
        {
            Suit = suit;
            Value = value;
        }
        //Metoden ändrar heltal till text
        public override string ToString()
        {
            string cardName;
            switch (Value)
            {
                case 1:
                    cardName = "Ace";
                    break;
                case 11:
                    cardName = "Jack";
                    break;
                case 12:
                    cardName = "Queen";
                    break;
                case 13:
                    cardName = "King";
                    break;
                default:
                    cardName = Value.ToString();
                    break;
            }

            return $"{cardName} of {Suit}";
        }

        //Metod används vid poängräkning
        public int GetValue()
        {
            switch (Value)
            {
                case 1:
                    return 11;
                case 11:
                case 12:
                case 13:
                    return 10;
                default:
                    return Value;
            }
        }
    }
}
