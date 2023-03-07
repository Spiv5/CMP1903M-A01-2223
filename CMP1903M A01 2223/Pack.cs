using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        
        //Initiliases a private list of cards, then creates a public accessor of it that is read only

        private List<Card> _pack = new List<Card>();

        public ReadOnlyCollection<Card> pack { get { return _pack.AsReadOnly();} private set { this._pack = new List<Card>(value);; } }
   
        //Constructor of the Pack class, creates 52 Card objects corresponding with a real deck
        public Pack()
        {
            //Initialise the card pack here

            for (int i = 0; i < 4;  i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    _pack.Add(new Card (j + 1, i + 1));
                    
                }
            }

            
        }

        //Shuffles the pack based on the type of shuffle
        //typeOfShuffle: 0 = Fisher-Yates shuffle, 1 = Riffle shuffle, 2 = No Shuffle

        public void shuffleCardPack(int typeOfShuffle)
        {

            //Creates a temporary private pack to edit that can later be sent back to the read only collection 

            Random r = new Random();
            List<Card> tempPack = new List<Card>(pack);

            //Fisher-Yates shuffle
            if (typeOfShuffle == 1)
            {
                for (int i = tempPack.Count-1; i >= 0; i--) //Starts with 51, loops down each time taking
                                                            //the card at the position of I and swapping it with a random card in the deck
                {
                    int j = r.Next(0, i + 1);
                    Card temp = tempPack[i];
                    tempPack[i] = tempPack[j];
                    tempPack[j] = temp;

                }
                Console.WriteLine("\nPerforming a Fisher-Yates Shuffle");
                pack = tempPack.AsReadOnly(); //Sets the read only collection as the new pack
     
            }

            //Riffle shuffle
            else if (typeOfShuffle == 2)
            {
                List<Card> tempHalf1 = new List<Card>(); //Creates two halves of the deck and creates a temporary deck
                List<Card> tempHalf2 = new List<Card>();

                tempHalf1 = tempPack.Take(tempPack.Count() / 2).ToList();
                tempHalf2 = tempPack.Skip(tempPack.Count() / 2).ToList();
                tempPack = new List<Card>();

                
                for (int i = tempPack.Count() / 2; i < 26; i++ ) //i = half the deck, for each iteration add one card from each half
                {
                    tempPack.Add(tempHalf1[i]);
                    tempPack.Add(tempHalf2[i]);
                }
                Console.WriteLine("\nPerforming a Riffle shuffle");
                pack = tempPack.AsReadOnly(); //Sets the read only collection as the new pack
            }

            else if (typeOfShuffle == 3)
            {
                Console.WriteLine("\nPerforming no shuffle");
            }

        }
        public Card deal()
        {
            List<Card> tempPack = new List<Card>(pack); //Brings in the read only collection as a temporary pack       
           
            Card cardToDeal = pack[0]; //Sets the first card as the card to deal and then removes it
            tempPack.RemoveAt(0);
            pack = tempPack.AsReadOnly(); //Resets the read only collection minus the dealt card
            Console.WriteLine($"\nYou deal {cardToDeal}"); //Prints the dealt card
            return cardToDeal; //Returns it if it needs to be used in that way 


        }
        public List<Card> dealCards(int amount)
        {
            List<Card> cardsToDeal = new List<Card>(); //Creates an empty list to hold cards
            List<Card> tempPack = new List<Card>(pack); //Brings in the read only collection as a temporary pack       

            for (int i = 0; i < amount; i++) //Deal "amount" of cards requested - add them to the list and remove it from the deck
            {
                cardsToDeal.Add(tempPack[0]);
                tempPack.RemoveAt(0);
            }
            foreach (Card card in cardsToDeal) //Print out dealt cardsq
            {
                Console.WriteLine($"\nYou deal {card}");
            }
            pack = tempPack.AsReadOnly(); //Resets the read only collection minus the dealt cards
            return cardsToDeal; //Returns it if it needs to be used in that way 

        }

        //Displays all of the cards in the pack at the point the function is called
        public void displayPack()
        {
            Console.WriteLine();
            foreach (Card c in this.pack)
            {
                Console.WriteLine(c);
            }
        }

        
    }
}
