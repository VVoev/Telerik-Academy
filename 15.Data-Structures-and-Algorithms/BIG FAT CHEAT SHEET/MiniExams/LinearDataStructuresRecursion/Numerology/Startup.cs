using System;
using System.Collections.Generic;

namespace DSA_Exams
{
    public class Startup
    {
        public static void Main()
        {
            var digitsAsString = Console.ReadLine();
            var digits = new List<int>();
            for (int i = 0; i < digitsAsString.Length; i++)
            {
                digits.Add(int.Parse(digitsAsString[i] + ""));
            }

            int[] digitsCounter = new int[10];
            GetDigits(digits, digitsCounter);

            Console.WriteLine(string.Join(" ", digitsCounter));
        }

        public static void GetDigits(List<int> digits, int[] digitsCounter)
        {
            if (digits.Count == 1)
            {
                digitsCounter[digits[0]]++;
                return;
            }

            for (int i = 0; i < digits.Count - 1; i++)
            {
                int a = digits[i];
                int b = digits[i + 1];

                int result = (a + b) * (a ^ b) % 10;

                digits.RemoveAt(i);
                digits[i] = result;

                GetDigits(digits, digitsCounter);

                digits[i] = b;
                digits.Insert(i, a);
            }
        }
    }
}
