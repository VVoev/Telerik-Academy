using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WordsCount
{
    static void Main()
    {
        string[] randomWords = Console.ReadLine()
                                      .Split(' ')
                                      .ToArray();
        Dictionary<string, int> countWords = new Dictionary<string, int>();

        foreach (string word in randomWords)
        {
            if (countWords.ContainsKey(word))
            {
                countWords[word]++;
            }
            else
            {
                countWords.Add(word, 1);
            }
        }
        var alphabeticalWords = countWords.OrderBy(x => x.Key);
        Console.WriteLine(string.Join(Environment.NewLine, alphabeticalWords));
    }
}
