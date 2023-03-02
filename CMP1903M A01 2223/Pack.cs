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
        
        
        private List<Card> _pack = new List<Card>();

        public ReadOnlyCollection<Card> pack { get { return _pack.AsReadOnly();} private set { this._pack = new List<Card>(value);; } }
   

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


        public void shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            //typeOfShuffle: 0 = Fisher-Yates shuffle, 1 = Riffle shuffle, 2 = No Shuffle

            
            Random r = new Random();
            List<Card> tempPack = new List<Card>(pack);

            //Fisher-Yates shuffle
            if (typeOfShuffle == 1)
            {

                for (int i = tempPack.Count-1; i >= 0; i--)
                {
                    int j = r.Next(0, i + 1);
                    Card temp = tempPack[i];
                    tempPack[i] = tempPack[j];
                    tempPack[j] = temp;

                }
                Console.WriteLine("\nPerforming a Fisher-Yates Shuffle");
                pack = tempPack.AsReadOnly();
     
            }

            //Riffle shuffle
            else if (typeOfShuffle == 2)
            {
                List<Card> tempHalf1 = new List<Card>();
                List<Card> tempHalf2 = new List<Card>();

                tempHalf1 = tempPack.Take(tempPack.Count() / 2).ToList();
                tempHalf2 = tempPack.Skip(tempPack.Count() / 2).ToList();
                tempPack = new List<Card>();

                
                for (int i = tempPack.Count() / 2; i < 26; i++ )
                {
                    tempPack.Add(tempHalf1[i]);
                    tempPack.Add(tempHalf2[i]);
                }
                Console.WriteLine("\nPerforming a Riffle shuffle");
                pack = tempPack.AsReadOnly();
            }

            else if (typeOfShuffle == 3)
            {
                Console.WriteLine("\nPerforming no shuffle");
            }

        }
        public Card deal()
        {
            //List<Card> tempPack = new List<Card>(pack);
            List<Card> tempPack = new List<Card>(pack);
            Card cardToDeal = pack[0];
          
            tempPack.RemoveAt(0);
            pack = tempPack.AsReadOnly();
            Console.WriteLine($"\nYou deal {cardToDeal}");
            return cardToDeal;


        }
        public List<Card> dealCards(int amount)
        {
            List<Card> cardsToDeal = new List<Card>();
            List<Card> tempPack = new List<Card>(pack);

            for (int i = 0; i < amount; i++) 
            {
                cardsToDeal.Add(tempPack[0]);
                tempPack.RemoveAt(0);
            }
            foreach (Card card in cardsToDeal)
            {
                Console.WriteLine($"\nYou deal {card}");
            }
            pack = tempPack.AsReadOnly();
            return cardsToDeal; 
            
        }

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
