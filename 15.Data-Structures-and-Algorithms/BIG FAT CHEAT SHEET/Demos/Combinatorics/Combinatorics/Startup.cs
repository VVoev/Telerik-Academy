using System;

namespace Combinatorics
{
    public class Startup
    {
        public static void Main()
        {
            var combinatoricsGenerator = new CombinatoricsGenerator();
            combinatoricsGenerator.GenerateCombinations(5, 3);
        }

        public static void Permute(int[] numbers, bool[] usedNumbers, int index, int n)
        {
            if (index >= numbers.Length)
            {
                Print(numbers);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!usedNumbers[i])
                {
                    usedNumbers[i] = true;
                    numbers[index] = i;

                    Permute(numbers, usedNumbers, index + 1, n);

                    usedNumbers[i] = false;
                }
            }
        }

        public static void Print(int[] numbers)
        {
            Console.WriteLine(string.Join(string.Empty, numbers));
        }

        public static int PrintParenthesis(string expression, int index)
        {
            if (index >= expression.Length)
            {
                return -1;
            }

            if (expression[index] == '(')
            {
                var endIndex = PrintParenthesis(expression, index + 1);
                if (endIndex == -1)
                {
                    Console.WriteLine("Missing closing parenthesis!");
                    return -1;
                }
                else
                {
                    Console.WriteLine(expression.Substring(index, endIndex - index + 1));
                }

                return PrintParenthesis(expression, endIndex + 1);
            }
            else if (expression[index] == ')')
            {
                return index;
            }

            return PrintParenthesis(expression, index + 1);
        }

        public static int GetFibonacci(int n, int[] memo)
        {
            if (n == 1 || n == 2)
            {
                return n;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }
            else
            {
                memo[n] = GetFibonacci(n - 1, memo) + GetFibonacci(n - 2, memo);
            }

            return memo[n];
        }
    }
}
