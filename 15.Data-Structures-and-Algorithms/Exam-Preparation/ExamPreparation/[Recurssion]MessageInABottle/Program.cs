using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Recurssion_MessageInABottle
{
    class Program
    {
        public static List<KeyValuePair<char, string>> ciphers = new List<KeyValuePair<char, string>>();
        public static string message;
        public static int count;
        public static List<string> solutions = new List<string>();
        static void Main(string[] args)
        {
            /* Input
            1122
            A1B12C11D2
            */
            message = Console.ReadLine();
            string cypher = Console.ReadLine();

            char key = char.MinValue;
            var value = new StringBuilder();

            for (int i = 0; i < cypher.Length; i++)
            {
                //if (char.IsLetter(cypher[i]))
                if (cypher[i] >= 'A' && cypher[i] <= 'Z')
                {
                    if(key != char.MinValue)
                    {
                        ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }
                    key = cypher[i];
                }
                else
                {
                    value.Append(cypher[i]);
                }
            }

            if (key != char.MinValue)
            {
                ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }

            Solve(0,new StringBuilder());
            Console.WriteLine(count);
            solutions.Sort();
            PrintEachSolution(solutions);
        }

        private static void PrintEachSolution(List<string> solutions)
        {
            foreach (var sol in solutions)
            {
                Console.WriteLine(sol);
            }
        }

        static void Solve(int secretMessageLenght, StringBuilder sb)
        {
            if(secretMessageLenght == message.Length)
            {
                count++;
                solutions.Add(sb.ToString());
                return;
            }

            foreach (var cipher in ciphers)
            {
                if (message.Substring(secretMessageLenght).StartsWith(cipher.Value))
                {
                    sb.Append(cipher.Key);
                    Solve(secretMessageLenght + cipher.Value.Length,sb);
                    sb.Length--;
                }
            }
        }
    }
}
