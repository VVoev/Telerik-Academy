using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCukiSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();
            int total = Count(word, text);

            for (int i = 1; i < word.Length; i++)
            {
                string prefix = word.Substring(0, i);
                string suffix = word.Substring(i, word.Length-i);

                total += Count(prefix, text) * Count(suffix, text);
            }
            Console.WriteLine(total);
        }

        static int Count(string pattern, string text)
        {
            int count = 0;
            int lastMatchIndex = 0;

            while (lastMatchIndex < text.Length)
            {
                int index = text.IndexOf(pattern, lastMatchIndex);
                if (index < 0)
                {
                    return count;
                }
                count++;
                lastMatchIndex = index + 1;
            }

            return count;
        }
    }
}
