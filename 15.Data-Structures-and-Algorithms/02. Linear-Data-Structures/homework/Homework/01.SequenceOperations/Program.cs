namespace _01.SequenceOperations
{
    using System;
    using System.Linq;

    public class Program
    {
        private static void Main()
        {
            var list =
                Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            var sum = list.Sum();
            var avg = list.Average();

            Console.WriteLine("Sum is: {0}", sum);
            Console.WriteLine("Average is: {0}", avg);
        }
    }
}
