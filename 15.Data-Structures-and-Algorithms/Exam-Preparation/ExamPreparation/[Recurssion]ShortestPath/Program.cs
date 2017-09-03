using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Recurssion_ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var symbols = new Symbols(input);

            if(symbols.CheckForStar() == false)
            {
                Console.WriteLine(1);
                Console.WriteLine(symbols.ToString());
                Environment.Exit(1);
            }

            symbols.Recurssion(0);

            foreach (var combo in symbols.SortedCombinations)
            {
                Console.WriteLine(combo);
            }

        }


    }

    class Symbols
    {
        public List<char[]> Combinations;
        public SortedSet<char[]> SortedCombinations;
        private char[] symbols;
        public Symbols(string input)
        {
            symbols = new char[input.Length];
            Parse(input);
            this.Combinations = new List<char[]>();
            this.SortedCombinations = new SortedSet<char[]>();
        }

        private void Parse(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                symbols[i] = input[i];
            }
        }

        public bool CheckForStar()
        {
            foreach (var symbol in this.symbols)
            {
                if(symbol == '*')
                {
                    return true;
                }
            }

            return false;
        }
    
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var symbol in this.symbols)
            {
                sb.Append(symbol);
            }
            return sb.ToString();
        }

        public void Recurssion(int index)
        {
            if(index == symbols.Length)
            {
                var x = symbols.Clone() as char[];
                var combo = x.ToString();
                Console.WriteLine(combo);
                //SortedCombinations.Add(x);
            }
            else if (symbols[index] != '*')
            {
                Recurssion(index + 1);
            }
            else
            {
                symbols[index] = 'S';
                Recurssion(index + 1);
                symbols[index] = 'R';
                Recurssion(index + 1);
                symbols[index] = 'L';
                Recurssion(index + 1);
                symbols[index] = '*';
            }
        }
    }
}
