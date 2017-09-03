using System;
using System.Collections.Generic;
using System.Text;

// cleaner solution
public class Program
{
    public static void Main()
    {
        int numbersCount = int.Parse(Console.ReadLine());
        var letters = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());

        Comb(0, 0, new int[n], numbersCount);
        // Console.WriteLine(string.Join("\n", numbersCombinations));

        CombLetters(0, 0, new char[n], letters.Length, letters);
        // Console.WriteLine(string.Join("\n", lettersCombinations));

        GenPermutations();

        Console.WriteLine(resultPermutations.Count);
        Console.WriteLine(string.Join("\n", resultPermutations));
    }

    static List<string> numbersCombinations = new List<string>();
    static List<string> lettersCombinations = new List<string>();

    static SortedSet<string> resultPermutations = new SortedSet<string>();

    static void GenPermutations()
    {
        foreach (var numberCombination in numbersCombinations)
        {
 
            var currentNumberCombination = numberCombination.Split(' ');
            foreach (var letterCombination in lettersCombinations)
            {
                var currentLetterCombination = letterCombination.Split(' ');
                GenerateVariationsNoReps(0, new string[currentNumberCombination.Length], currentLetterCombination, new bool[currentLetterCombination.Length], currentNumberCombination);
            }
        }
    }

    static void Merge(string[] current, string[] toMerge)
    {
        var builder = new StringBuilder(current.Length);
        for (int i =0; i < current.Length; i++)
        {
            builder.Append(string.Format("{0}{1}", toMerge[i], current[i]));
            if (i < current.Length - 1)
            {
                builder.Append('-');
            }
        }

        resultPermutations.Add(builder.ToString().Trim());
    }

    static void GenerateVariationsNoReps(int index, string[] current, string[] all, bool[] used, string[] toMerge)
    {
        if (index >= current.Length)
        {
            Merge(current, toMerge);
        }
        else
        {
            for (int i = 0; i < current.Length; i++)
                if (!used[i])
                {
                    used[i] = true;
                    current[index] = all[i];
                    GenerateVariationsNoReps(index + 1, current, all, used, toMerge);
                    used[i] = false;
                }
        }
    }

    static void Comb(int index, int start, int[] arr, int n)
    {
        if (index >= arr.Length)
        {
            numbersCombinations.Add(string.Join(" ", arr));
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                arr[index] = i;
                Comb(index + 1, i + 1, arr, n);
            }
        }
    }

    static void CombLetters(int index, int start, char[] arr, int n, string letters)
    {
        if (index >= arr.Length)
        {
            lettersCombinations.Add(string.Join(" ", arr));
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                arr[index] = letters[i];
                CombLetters(index + 1, i + 1, arr, n, letters);
            }
        }
    }
}

/* Simpler Solution
 //using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GirlsGoneWild
//{
//    public class Program
//    {
//        static int girlsCount;
//        static string skirts;
//        static int shirtsCount;

//        public static void Main()
//        {
//            shirtsCount = int.Parse(Console.ReadLine());
//            skirts = Console.ReadLine();
//            girlsCount = int.Parse(Console.ReadLine());

//            string[] current = new string[girlsCount];
//            Solve(current, 0, new bool[skirts.Length], 0);

//            Console.WriteLine(results.Count);
//            Console.WriteLine(string.Join("\n", results));
//        }

//        static SortedSet<string> results = new SortedSet<string>();

//        public static void Solve(string[] current, int currentIndex, bool[] visitedSkirts, int shirtIndex)
//        {
//            if (currentIndex >= current.Length)
//            {
//                results.Add(string.Join("-", current));
//                return;
//            }

//            for (int i = shirtIndex; i < shirtsCount; i++)
//            {
//                for (int j = 0; j < skirts.Length; j++)
//                {
//                    if (!visitedSkirts[j])
//                    {
//                        visitedSkirts[j] = true;
//                        current[currentIndex] = i + "" + skirts[j];
//                        Solve(current, currentIndex + 1, visitedSkirts, i + 1);
//                        visitedSkirts[j] = false;
//                    }
//                }
//            }
//        }
//    }
//}
 * */
