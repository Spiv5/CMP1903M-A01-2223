using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    internal class testing
    {
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


        }
        
        
    }
}
