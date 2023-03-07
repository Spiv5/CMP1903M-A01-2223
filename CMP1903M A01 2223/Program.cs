using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        //Creates a pack, runs the test function on it, makes a new pack and sends the user to the main menu with a new pack
        static void Main(string[] args)
        {
            
            Pack pack1 = new Pack();
            testing.testingFunction();
            Console.ReadKey();
            Menu(pack1);
            Console.ReadKey();

        }

        

        static void Menu(Pack pack)
        {

            //If the deck is empty inform the user and informally end the program

            if (pack.pack.Count() == 0)
            {
                Console.WriteLine("The deck is empty!");
                while (true) { Console.ReadKey(); }
            }

            //Asks the user what they would like to do 
            Console.WriteLine("\nWhat would you like to do?\n\n1) Shuffle the pack\n2) Deal a single card\n3) Deal multiple cards\n4) Display the pack\n");
            string response = Console.ReadLine();
            if (response == "1") //Shuffles the pack
            {
                Console.WriteLine("\nWhat kind of shuffle would you like to perform?\n\n1) Fisher-Yates shuffle\n2) Riffle Shuffle\n3) No Shuffle\n");
                response = Console.ReadLine(); //Checks for the requested shuffle then runs that function
                if (response == "1") { pack.shuffleCardPack(1); }
                else if (response == "2") { pack.shuffleCardPack(2); }
                else if (response == "3") { pack.shuffleCardPack(3); }
                else { Console.WriteLine("I did not understand your input, please try again"); Menu(pack); } //If it was not 1, 2 or 3 then re runs menu
            }
            else if (response == "2") //Deals a card via deal()
            {
                pack.deal(); 
            }
            else if (response == "3") //Deals multiple cards based on the users input, checks to see if that many cards are available and if so deals that many
            {
                Console.WriteLine("How many cards would you like to deal?");
                
                try
                {
                    int amountToDeal = Convert.ToInt32(Console.ReadLine());
                    if (amountToDeal > pack.pack.Count)
                    {
                        Console.WriteLine("There aren't that many cards in the deck!");
                        Menu(pack);
                    }
                    pack.dealCards(amountToDeal);
                }
                catch (Exception e)
                {
                    Console.WriteLine("I did not understand your input, please try again");
                    Menu(pack);
                }
                
            }
            else if (response == "4") //Displays pack
            {
                pack.displayPack();
                Menu(pack);
            }
            else { Console.WriteLine("I did not understand your input, please try again"); Menu(pack); } //Catches any erroneous input and reruns the menu
            Menu(pack);


        }
    }
}

