using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());



            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var k = line[1];

                var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


                Solve(-1, 0, numbers, numbers.Length, k, 0);

        
            }
        }

        private static void Solve(int i, int par, int[] a, int n,int k, int current_ans)
        {
            // If number of partitions is more than k
            if (par > k)
                return;

            // If we have mad k partitions and have
            // reached last element
            if (par == k && i == n - 1)
            {
                var ans = int.MaxValue;
                ans = Math.Min(ans, current_ans);
                Console.WriteLine(ans);
                return;
            }

            // 1) Partition array at different points
            // 2) For every point, increase count of 
            //    partitions, "par" by 1.
            // 3) Before recursive call, add cost of 
            //    the partition to current_ans
            for (int j = i + 1; j < n; j++)
                Solve(j, par + 1, a, n, k, current_ans +
                          (a[j] - a[i + 1]) * (a[j] - a[i + 1]));
            Console.WriteLine();
        }

        private static int MinSum(int[] numbers, int n, int k)
        {
            // k must be greater
            if (n < k)
            {
                return -1;
            }

            // Compute sum of first window of size k
            int res = 0;
            for (int i = 0; i < k; i++)
                res += numbers[i];

            // Compute sums of remaining windows by
            // removing first element of previous
            // window and adding last element of 
            // current window.
            int curr_sum = res;
            for (int i = k; i < n; i++)
            {
                curr_sum += numbers[i] - numbers[i - k];
                res = Math.Max(res, curr_sum);
            }

            return res;
        }
    }
}
