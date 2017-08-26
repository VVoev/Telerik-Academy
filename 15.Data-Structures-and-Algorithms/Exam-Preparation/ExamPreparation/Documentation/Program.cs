using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    class Program
    {
        public static void Main()
        {
            var sol = new Solution();
            sol.BullShit();
        }
    }
    public class Solution
    {
        public void BullShit()
        {
            string text = Console.ReadLine().ToLower();

            int operations = 0;
            int englishCharactersCount = 26;
            int minCharValue = 97;
            int maxCharValue = 122;

            int left = 0;
            int right = text.Length - 1;
            while (left < right)
            {
                int leftChar = text[left];
                int rightChar = text[right];

                while ((leftChar < minCharValue || leftChar > maxCharValue) && left < right)
                {
                    left++;
                    leftChar = text[left];
                }

                while ((rightChar < minCharValue || rightChar > maxCharValue) && left < right)
                {
                    right--;
                    rightChar = text[right];
                }

                if (left >= right)
                {
                    break;
                }

                int diff = Math.Abs(text[left] - text[right]);
                operations += Math.Min(diff, englishCharactersCount - diff);

                left++;
                right--;
            }

            Console.WriteLine(operations);
        }
    }
}
