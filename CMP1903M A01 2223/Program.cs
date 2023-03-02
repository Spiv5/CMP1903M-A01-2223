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
        static void Main(string[] args)
        {

            Pack pack1 = new Pack();


            Menu(pack1);
            Console.ReadKey();

        }

        static void Menu(Pack pack)
        {

            testing.testingFunction();
            Console.WriteLine("\nTesting function output above. It does as follows:\n• Performs a Riffle shuffles\n• Performs a Fisher-Yates shuffle\n• Deals one card\n• Deals 5 cards\n• Displays the pack after each step\nPress any key to continue to main menu");
            Console.ReadKey();
            Console.Clear();

            if (pack.pack.Count() == 0)
            {
                Console.WriteLine("The deck is empty!");
                while (true) { Console.ReadKey(); }
                
            }
            Console.WriteLine("\nWhat would you like to do?\n\n1) Shuffle the pack\n2) Deal a single card\n3) Deal multiple cards\n4) Display the pack\n");
            string response = Console.ReadLine();
            if (response == "1")
            {
                Console.WriteLine("\nWhat kind of shuffle would you like to perform?\n\n1) Fisher-Yates shuffle\n2) Riffle Shuffle\n3) No Shuffle\n");
                response = Console.ReadLine();
                if (response == "1") { pack.shuffleCardPack(1); }
                else if (response == "2") { pack.shuffleCardPack(2); }
                else if (response == "3") { pack.shuffleCardPack(3); }
                else { Console.WriteLine("I did not understand your input, please try again"); Menu(pack); } 
            }
            else if (response == "2")
            {

                pack.deal();
            }
            else if (response == "3")
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
            else if (response == "4")
            {
                pack.displayPack();
                Menu(pack);
            }
            else { Console.WriteLine("I did not understand your input, please try again"); Menu(pack); }
            Menu(pack);


        }
    }
}

