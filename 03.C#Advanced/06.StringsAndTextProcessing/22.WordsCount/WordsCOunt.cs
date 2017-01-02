using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WordsCount
{
    static void Main()
    {
        Dictionary<string, int> lettersCount = new Dictionary<string, int>();

        string[] words = Console.ReadLine()
                                .Split(' ')
                                .ToArray();
        foreach (var word in words)
        {
            if (lettersCount.ContainsKey(word))
            {
                lettersCount[word]++;
            }
            else
            {
                lettersCount.Add(word, 1);
            }
        }
        var ascendingLetters = lettersCount.OrderBy(x => x.Key);
        Console.WriteLine(string.Join(Environment.NewLine, ascendingLetters));
    }
}
