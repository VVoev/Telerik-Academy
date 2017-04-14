using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions_Homework.Utilities
{
    public static class Utilities
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            Validator.Validator.IsArrayNullOrEmpty(arr);

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }
            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            Validator.Validator.IsArrayNullOrEmpty(str);
            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("The count of text you required to extract is bigger then the whole text");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }
            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            bool isPrime = true;
            if (number < 1)
            {
                throw new ArgumentException("Number smaller than one cannot be a prime");
            }
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                }
            }

            if (isPrime)
            {
                Console.WriteLine($@"Number {number} is Prime");
            }
        }
    }
}
