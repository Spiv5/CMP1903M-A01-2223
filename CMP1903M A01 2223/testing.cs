using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    internal class testing
    {

        //Creates a test pack and runs multiple functions on it to prove functionality 

        public static void testingFunction()
        {
            Pack testPack = new Pack();

            testPack.shuffleCardPack(2);
            testPack.displayPack();

            testPack.shuffleCardPack(1);
            testPack.displayPack();

            testPack.deal();
            testPack.displayPack();

            testPack.dealCards(5);
            testPack.displayPack();

            Console.WriteLine("\nTesting function output above. It does as follows:\n• Performs a Riffle shuffles\n• Performs a Fisher-Yates shuffle\n• Deals one card\n• Deals 5 cards\n• Displays the pack after each step\n\nPress any key to continue to main menu");

        }
        
        
    }
}
