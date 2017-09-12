using System;
using System.Collections.Generic;
using System.Numerics;

namespace DP_demos
{
    class Program
    {
        static List<BigInteger> fibonacciMemo = new List<BigInteger> { 1, 1 };

        static BigInteger Fibonacci(int n)
        {
            if(fibonacciMemo.Count <= n)
            {
                var result = Fibonacci(n - 1) + Fibonacci(n - 2);
                fibonacciMemo.Add(result);
            }

            return fibonacciMemo[n];
        }

        static void Main()
        {
            var n = 1000;
            var fibs = new BigInteger[n + 1];

            fibs[0] = 1;
            fibs[1] = 1;
            for (int i = 2; i <= n; ++i)
            {
                fibs[i] = fibs[i - 1] + fibs[i - 2];
            }

            Console.WriteLine(fibs[n]);

            BigInteger firstNumber = 1;
            BigInteger secondNumber = 1;
            for (int i = 2; i <= n; ++i)
            {
                var currentNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = currentNumber;
            }

            Console.WriteLine(secondNumber);
        }
    }
}
