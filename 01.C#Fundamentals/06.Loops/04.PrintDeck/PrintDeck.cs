using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrintDeck
{
    static void Main()
    {
        string input = Console.ReadLine().ToUpper();
        Dictionary<string, int> cardNumbers = new Dictionary<string, int>()
        {
           { "2", 1},
           { "3", 2},
           { "4", 3},
           { "5", 4},
           { "6", 5},
           { "7", 6},
           { "8", 7},
           { "9", 8},
           { "10",9},
           { "J", 10},
           { "Q", 11},
           { "K", 12},
           { "A", 13},
                      };
        string[] suits = { "of spades", "of clubs", "of hearts", "of diamonds" };
        //char[] suits = { '\x05', '\x04', '\x03', '\x06' };
        //int numberCards = 13;
        int numberColours = 4;
        int numberToPrint = cardNumbers[input];
        for (int i = 0; i < numberToPrint; i++)
        {
            for (int j = 0; j < numberColours; j++)
            {
                if (j == 0)
                {
                    Console.Write("{0} {1}, ", cardNumbers.ElementAt(i).Key, suits[j]);
                }
                else if (j == 1)
                {
                    Console.Write("{0} {1}, ", cardNumbers.ElementAt(i).Key, suits[j]);
                }
                else if (j == 2)
                {
                    Console.Write("{0} {1}, ", cardNumbers.ElementAt(i).Key, suits[j]);
                }
                else if (j == 3)
                {
                    Console.Write("{0} {1} ", cardNumbers.ElementAt(i).Key, suits[j]);
                }
            }
            Console.WriteLine();
        }
    }
}
