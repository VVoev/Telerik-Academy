using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesInABottle
{
    public class Program
    {
        public static void Main()
        {
            string secretMessage = Console.ReadLine();
            string cipher = Console.ReadLine();

            var cipherCodes = new Dictionary<long, char>();

            var currentKey = new StringBuilder();
            char currentValue = '\0';
            for (int i = 0; i < cipher.Length; i++)
            {
                if (char.IsDigit(cipher[i]))
                {
                    currentKey.Append(cipher[i]);
                    if (i == cipher.Length - 1)
                    {
                        cipherCodes.Add(long.Parse(currentKey.ToString().Trim()), currentValue);
                    }
                }

                if (char.IsLetter(cipher[i]))
                {
                    if (i > 0)
                    {
                        cipherCodes.Add(long.Parse(currentKey.ToString().Trim()), currentValue);
                        currentKey.Clear();
                    }

                    currentValue = cipher[i];
                }
            }

            var result = FindMatches(secretMessage, 0, cipherCodes);
            Console.WriteLine(result);

            if (results.Count > 0)
            {
                results.Sort();
                Console.WriteLine(string.Join("\n", result));
            }
        }

        static List<char> currentMatch = new List<char>();

        static List<string> results = new List<string>();

        public static int FindMatches(string secretMessage, int index, Dictionary<long, char> cipherCodes)
        {
            if (index >= secretMessage.Length)
            {
                results.Add(string.Join("", currentMatch));
                return 1;
            }

            long number = 0;
            int result = 0;
            while (index < secretMessage.Length)
            {
                number = number * 10 + (secretMessage[index] - '0');
                if (cipherCodes.ContainsKey(number))
                {
                    currentMatch.Add(cipherCodes[number]);

                    result += FindMatches(secretMessage, index + 1, cipherCodes);
                    currentMatch.RemoveAt(currentMatch.Count - 1);
                }

                index++;
            }

            return result;
        }
    }
}
