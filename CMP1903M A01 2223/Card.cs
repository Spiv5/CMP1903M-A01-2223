using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation

        private int cardValue;
        private int cardSuit;

        private string[] suitName = { "Spades","Clubs","Diamonds","Hearts" };
        private string[] valueName = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        
        public Card(int _value, int _suit)
        {
            this.Value = _value;
            this.Suit = _suit;
        }



        public int Value
        {
            get { return cardValue; }
            set
            {
                if (value >= 1 && value <= 13)
                {
                    cardValue = value;
                }
                else { Console.WriteLine("Invalid Value"); }
            }
        }


        public int Suit
        {
            get { return cardSuit; }
            set
            {
                if (value >= 1 && value <= 4)
                {
                    cardSuit = value;
                }
                else { Console.WriteLine("Invalid Suit"); }
            }
        }

        public override string ToString()
        {
            //return $"Value: {Value} Suit: {Suit}";
            return $"{valueName[Value-1]} of {suitName[Suit-1]}";
        }




    }
 
}
