using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackSpel
{
    internal class Card
    {
        public string Suit {  get; set; }
        public int Value { get; set; }

        public Card(string suit, int value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
