using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseSentence
{
    static void Main()
    {
        string sentence = Console.ReadLine();
        char finalSign = sentence[sentence.Length - 1];
        sentence = sentence.Remove(sentence.Length - 1);
        string[] words = sentence
                              .Split(' ')
                              .ToArray();
        for (int i = 0; i < words.Length / 2; i++)
        {
            string currentWord = words[i];
            words[i] = words[words.Length - 1 - i];
            words[words.Length - 1 - i] = currentWord;
        }
        Console.WriteLine(string.Join(" ", words)+ finalSign);
    }
}
