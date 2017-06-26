using System;

namespace _3.Generating_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = 3;
            int startNum = 5;
            int endNum = 10;

            int[] arr = new int[numbers];
            GenerateCombinations(arr, 0, startNum, endNum);
        }

        private static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(", ", arr));
            }

            else
            {
                for (int i = startNum; i < endNum; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index+1,startNum,endNum);
                }
            }


        }
    }
}
