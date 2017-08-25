using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DP_SuperSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var K = input[0];
            var N = input[1];

            var result = SuperSum(K, N);
            Console.WriteLine(result);
        }

        private static int SuperSum(int k, int n)
        {
            int ret = 0;
            if (k == 0)
            {
                return n;
            }

            for (int i = 1; i <= n; i++)
            {
                ret += SuperSum(k - 1, i);
            }
            return ret;
        }
    }
}
