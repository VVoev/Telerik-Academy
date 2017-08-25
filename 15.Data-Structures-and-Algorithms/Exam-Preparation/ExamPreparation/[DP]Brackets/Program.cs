using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DP_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int N = input.Length;
            long[,] DP = new long[N + 1, N + 2];
            DP[0, 0] = 1;
            for (int k = 1; k <= N; k++)
            {
                if (input[k - 1] == '(')
                {
                    DP[k, 0] = 0;
                }
                else
                {
                    DP[k, 0] = DP[k - 1, 1];
                }
                for (int c = 1; c <= N; c++)
                {
                    if (input[k - 1] == '(')
                    {
                        DP[k, c] = DP[k - 1, c - 1];
                    }
                    else if (input[k - 1] == ')')
                    {
                        DP[k, c] = DP[k - 1, c + 1];
                    }
                    else
                    {
                        DP[k, c] = DP[k - 1, c - 1] + DP[k - 1, c + 1];
                    }
                }
            }
            Console.WriteLine(DP[N, 0]);
        }
    }
}
