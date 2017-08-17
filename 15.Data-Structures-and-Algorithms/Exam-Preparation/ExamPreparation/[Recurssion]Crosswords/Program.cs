using System;
using System.Collections.Generic;
using System.Text;

namespace _Recurssion_Crosswords
{
    class Program
    {
        static HashSet<string> allWords = new HashSet<string>();
        static string[] words;
        static string[] crosswords;
        
        static bool CheckVertical()
        {
            StringBuilder currentWord = new StringBuilder();
            for (int i = 0; i < crosswords.Length; i++)
            {
                currentWord.Clear();
                for (int j = 0; j < crosswords.Length; j++)
                {
                    currentWord.Append(crosswords[j][i]);
                }

                if (!allWords.Contains(currentWord.ToString()))
                {
                    return false;
                }
            }

            return true;
        }
        static void Print()
        {
            //Console.WriteLine($"Result");
            for (int i = 0; i < crosswords.Length; i++)
            {
                Console.WriteLine(crosswords[i]);
            }
        }
        static void Solver(int indexLine)
        {
            if(indexLine >= crosswords.Length)
            {
                if (CheckVertical())
                {
                    Console.WriteLine("-------------------Final----------");
                    Print();
                    Environment.Exit(1);
                }
                return;
            }
            Console.WriteLine("------------------");
            for (int i = 0; i < words.Length; i++)
            {
                crosswords[indexLine] = words[i];
                Print();
                Solver(indexLine + 1);
                crosswords[indexLine] = null;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            words = new string[n * 2];
            crosswords = new string[n];

            for (int i = 0; i < 2*n; i++)
            {
                words[i] = Console.ReadLine();
                allWords.Add(words[i]);
            }
            Array.Sort(words);

            Solver(0);
            Console.WriteLine("NO SOLUTION!");
        }
    }
}
