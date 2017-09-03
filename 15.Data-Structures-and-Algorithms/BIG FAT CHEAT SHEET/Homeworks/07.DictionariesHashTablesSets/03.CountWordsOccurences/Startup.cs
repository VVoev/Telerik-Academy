using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.CountWordsOccurences
{
    class Startup
    {
        static void Main()
        {
            string filePath = @"..\..\words.txt";

            var wordsDictionary = GetWordsOccurencesFromFile(filePath);

            foreach (var kv in wordsDictionary)
            {
                Console.WriteLine($"{kv.Key} => {kv.Value} times.");
            }
        }

        public static Dictionary<string, int> GetWordsOccurencesFromFile(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            var separators = new List<char>();
            for (int i =0; i < fileText.Length; i++)
            {
                if (!char.IsLetterOrDigit(fileText[i]))
                {
                    separators.Add(fileText[i]);
                }
            }

            var words = fileText.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            var dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dictionary.ContainsKey(word.ToLower()))
                {
                    dictionary[word.ToLower()]++;
                }
                else
                {
                    dictionary[word.ToLower()] = 1;
                }
            }

            return dictionary;
        }
    }
}
