using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    class Program
    {

        static char []separators = new char[] { '-', ' ', ':',',' };
        static HashSet<string> allWords = new HashSet<string>();
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());
            var words = new string[N];

            Text(N, words);

            int X = int.Parse(Console.ReadLine());
            var searchedWords = new string[X];
            SearchedWords(X, searchedWords);



            foreach (var word in searchedWords)
            {
                CheckIfWordIsInAllWords(word);
            }

            PrintCombo();

        }

        private static void PrintCombo()
        {
            foreach (var word in combo)
            {
                Console.WriteLine(@"{0} -> {1}",word.Key,word.Value);
            }
        }

        private static Dictionary<string, int> combo = new Dictionary<string, int>();
        private static void CheckIfWordIsInAllWords(string word)
        {

            bool beenHere = false;
            var originWord = word;
            foreach (var duma in allWords )
            {
                int counter = 0;
                word = word.ToLower();
                foreach (var letter in word)
                {
                    if (duma.ToLower().Contains(letter))
                    {
                        counter++;
                    }
                }
                if(counter == word.Length)
                {
                    if (!combo.ContainsKey(originWord))
                    {
                        combo[originWord] = 1;
                        beenHere = true;
                    }
                    else
                    {
                        combo[originWord]++;
                        beenHere = true;
                    }
                }
            }
            if (!beenHere)
            {
                combo[originWord] = 0;
            }
        }

        private static void SearchedWords(int X, string[] searchedWords)
        {
            for (int i = 0; i < X; i++)
            {
                searchedWords[i] = Console.ReadLine();
            }
        }
        private static void Text(int N, string[] words)
        {
            for (int i = 0; i < N; i++)
            {
                words[i] = Console.ReadLine();
                var cleanWords = words[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in cleanWords)
                {
                    allWords.Add(word.ToLower());
                }
            }
        }
    }
}
