using System;
using System.Linq;

class PlayCard
{
    static void Main()
    {
        string[] cards = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string input = Console.ReadLine();
        if (cards.Contains(input))
        {
            Console.WriteLine("yes {0}", input.ToUpper());
        }
        else
        {
            Console.WriteLine("no {0}", input.ToLower());
        }
    }
}
