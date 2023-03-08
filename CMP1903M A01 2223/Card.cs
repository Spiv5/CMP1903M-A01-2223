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
        

        //Initialises private variables and names of each of the suits and values
        private int cardValue;
        private int cardSuit;

        private string[] suitName = { "Spades","Clubs","Diamonds","Hearts" };
        private string[] valueName = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        

        //Constructor of the Card class, sets the public value to the passed parameters
        public Card(int _value, int _suit)
        {
            this.Value = _value;
            this.Suit = _suit;
        }

        //Public accessor for the Value and Suit variables with validation 

        public int Value
        {
            get { return cardValue; }
            set
            {
                if (value >= 1 && value <= 13) //If someone uses the class and instantiates there own card object this validates whether it has a valid value
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
                if (value >= 1 && value <= 4) //If someone uses the class and instantiates there own card object this validates whether it has a valid suit
                {
                    cardSuit = value;
                }
                else { Console.WriteLine("Invalid Suit"); }
            }
        }

        //Overrides the default class ToString method to allow easier output of the Card's data

        public override string ToString()
        {
            return $"{valueName[Value-1]} of {suitName[Suit-1]}";
        }




    }
 
}
