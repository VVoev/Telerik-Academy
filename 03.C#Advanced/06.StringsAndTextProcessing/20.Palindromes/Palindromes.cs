using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Palindromes
{
    static void Main()
    {
        string word = Console.ReadLine();
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                Console.WriteLine("Word {0} is not palindrome", word);
                return;
            }
        }
        Console.WriteLine("Word {0} is palindrome", word);
    }
}
//using System;

//class LongestIncreasingSequence
//{
//    static int[] output;
//    static int maxLength;
//    static void GenerateSubset(int[] arr, int[] subset, int index, int current, int elementsInSubset)
//    {
//        if (index == elementsInSubset)
//        {
//            CheckSubsets(subset, elementsInSubset);
//            return;
//        }

//        for (int i = current; i < arr.Length; i++)
//        {
//            subset[index] = arr[i];
//            GenerateSubset(arr, subset, index + 1, i + 1, elementsInSubset);
//        }
//    }

//    static void CheckSubsets(int[] Sub, int elinSub)
//    {
//        for (int i = 1; i < elinSub; i++)
//        {
//            if (Sub[i] < Sub[i - 1])
//            {
//                return;
//            }
//            if (i > maxLength)
//            {
//                maxLength = i;
//                for (int j = 0; j <= maxLength; j++)
//                {
//                    output[j] = Sub[j];
//                }
//            }
//        }
//    }

//    static void Main()
//    {
//        int n = int.Parse(Console.ReadLine());
//        int[] arr = new int[n];
//        for (int index = 0; index < n; index++)
//        {
//            arr[index] = int.Parse(Console.ReadLine());
//        }
//        output = new int[n];
//        int[] subset = new int[n];
//        for (int i = 1; i <= n; i++)
//        {
//            GenerateSubset(arr, subset, 0, 0, i);
//        }
//        Console.WriteLine(arr.Length - maxLength - 1);
//    }
//}
