using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Documentation
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();

            int leftIndex = 0;
            int rightIndex = text.Length - 1;

            int operationsCount = 0;
            while (leftIndex < rightIndex)
            {
                while (leftIndex < rightIndex && !char.IsLetter(text[leftIndex]))
                {
                    leftIndex++;
                }

                while (rightIndex > leftIndex && !char.IsLetter(text[rightIndex]))
                {
                    rightIndex--;
                }

                if (leftIndex >= rightIndex)
                {
                    break;
                }

                char leftSymbol = text[leftIndex];
                char rightSymbol = text[rightIndex];

                if (leftSymbol == rightSymbol)
                {
                    leftIndex++;
                    rightIndex--;
                    continue;
                }

                var max = Math.Max((int)leftSymbol, (int)rightSymbol);
                var min = Math.Min((int)leftSymbol, (int)rightSymbol);

                var normalDiff = max - min;
                var cyclycDiff = 'z' - max + min + 1 - 'a';

                operationsCount += normalDiff < cyclycDiff ? normalDiff : cyclycDiff;

                leftIndex++;
                rightIndex--;
            }

            Console.WriteLine(operationsCount);
        }
    }
}
