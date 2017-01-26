namespace _02.CombinationsWithDuplicates
{
    using System;
    using System.Text;

    class Program
    {
        private static int[] arr;
        private static int n;
        private static int k;
        private static StringBuilder sb;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number n:");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number k for generating from n:");
            k = int.Parse(Console.ReadLine());

            sb = new StringBuilder();
            arr = new int[k];

            GenerateCombinations(0, 0);

            Console.WriteLine(sb.ToString().Trim(new char[] { ',', ' ' }));
        }

        private static void GenerateCombinations(int index, int start)
        {
            if (index >= k)
            {
                sb.Append("[");
                sb.Append(string.Join("-", arr));
                sb.Append("]");
                sb.Append(Environment.NewLine);
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i + 1;
                    GenerateCombinations(index + 1, i);
                }
            }
        }
    }
}