namespace SubsetSumProblem
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var set = new[] { 3, 34, 4, 12, 5, 2 };
            var sum = 45; // 27
            Console.WriteLine("Numbers: {0}", string.Join(", ", set));
            Console.WriteLine("Searching for: {0}", sum);
            if (IsSubsetSum(set, sum))
            {
                Console.WriteLine("Found a subset with given sum");
            }
            else
            {
                Console.WriteLine("No subset with given sum");
            }
        }

        // Returns true if there is a subset of set with sum equal to given sum
        private static bool IsSubsetSumRecursive(int[] set, int n, int sum)
        {
            // Base Cases
            if (sum == 0)
            {
                return true;
            }

            if (n == 0 && sum != 0)
            {
                return false;
            }

            // If last element is greater than sum, then ignore it
            if (set[n - 1] > sum)
            {
                return IsSubsetSumRecursive(set, n - 1, sum);
            }

            /* else, check if sum can be obtained by any of the following
               (a) including the last element
               (b) excluding the last element   */
            return IsSubsetSumRecursive(set, n - 1, sum) || IsSubsetSumRecursive(set, n - 1, sum - set[n - 1]);
        }

        // Returns true if there is a subset of set[] with sun equal to given sum
        private static bool IsSubsetSum(int[] set, int sum)
        {
            const int NotSet = -1;
            var sumOfAll = set.Sum();
            var last = new int[sumOfAll + 1];
            var currentSum = 0;
            for (var i = 1; i < sumOfAll; i++)
            {
                last[i] = NotSet;
            }

            for (var i = 0; i < set.Length; i++)
            {
                for (var j = currentSum; j + 1 > 0; j--)
                {
                    if (last[j] != NotSet && last[j + set[i]] == NotSet)
                    {
                        last[j + set[i]] = i;
                    }
                }

                currentSum += set[i];
            }

            if (last[sum] != NotSet)
            {
                Console.Write("{0} = ", sum);
                while (sum > 0)
                {
                    var number = set[last[sum]];
                    sum -= number;
                    if (sum > 0)
                    {
                        Console.Write("{0} + ", number);
                    }
                    else
                    {
                        Console.Write(number);
                    }
                }

                Console.WriteLine();
            }

            return last[sum] != NotSet;
        }
    }
}