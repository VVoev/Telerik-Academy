using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LettersCount
{
    static void Main()
    {
        Dictionary<char, int> lettersCount = new Dictionary<char, int>();

        string text = Console.ReadLine();
        foreach (var symbol in text)
        {
            if (Char.IsLetter(symbol))
            {
                if (lettersCount.ContainsKey(symbol))
                {
                    lettersCount[symbol]++;
                }
                else
                {
                    lettersCount.Add(symbol, 1);
                }
            }
        }
        var ascendingLetters = lettersCount.OrderBy(x => x.Key);
        Console.WriteLine(string.Join(Environment.NewLine,ascendingLetters));
    }
}
