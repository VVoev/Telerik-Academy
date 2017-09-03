using System;

namespace Trabi
{
    public class Startup
    {
        public static void Main()
        {
            int pipesCount = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[] pipes = new int[pipesCount];
            for (int i = 0; i < pipesCount; i++)
            {
                pipes[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(pipes);

            int match = -1;
            int left = 0;
            int right = pipes[pipes.Length - 1];
            while (left != right)
            {
                int middle = (left + right) / 2;
                if (IsMatch(pipes, middle, m))
                {
                    left = middle + 1;
                    match = middle;
                }
                else
                {
                    right = middle;
                }
            }

            if (IsMatch(pipes, left, m))
            {
                Console.WriteLine(left);
            }
            else
            {
                Console.WriteLine(match);
            }
        }

        public static bool IsMatch(int[] pipes, int divisor, int m)
        {
            int slicedPipes = 0;
            for (int i = 0; i < pipes.Length; i++)
            {
                slicedPipes += pipes[i] / divisor;
            }

            if (slicedPipes >= m)
            {
                return true;
            }

            return false;
        }
    }
}