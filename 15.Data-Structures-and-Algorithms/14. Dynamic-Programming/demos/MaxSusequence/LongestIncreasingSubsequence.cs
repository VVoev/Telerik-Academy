using System;
using System.Collections.Generic;

public static class LongestIncreasingSubsequence
{
    private const int NoPrevious = -1;

    public static void Main()
    {
        var sequence = new[] { 1, 8, 2, 7, 3, 4, 1, 6 };
        var length = new int[sequence.Length];
        var predecessor = new int[sequence.Length];
        var bestIndex = CalculateLongestIncreasingSubsequence(sequence, length, predecessor);

        Console.WriteLine("sequence    = " + string.Join(", ", sequence));
        Console.WriteLine("length      = " + string.Join(", ", length));
        Console.WriteLine("predecessor = " + string.Join(", ", predecessor));

        PrintLongestIncreasingSubsequence(sequence, predecessor, bestIndex);
    }

    private static int CalculateLongestIncreasingSubsequence(int[] sequence, int[] length, int[] predecessor)
    {
        var bestEnd = 0;
        var bestIndex = 0;
        for (var i = 0; i < sequence.Length; i++)
        {
            length[i] = 1;
            predecessor[i] = NoPrevious;
            for (var k = 0; k <= i - 1; k++)
            {
                if (sequence[k] < sequence[i])
                {
                    if (length[k] + 1 > length[i])
                    {
                        length[i] = length[k] + 1;
                        predecessor[i] = k;

                        if (length[i] > bestEnd)
                        {
                            bestEnd = length[i];
                            bestIndex = i;
                        }
                    }
                }
            }
        }

        return bestIndex;
    }
    
    private static void PrintLongestIncreasingSubsequence(int[] sequence, int[] predecessor, int maxElementIndex)
    {
        var lis = new List<int>();
        while (maxElementIndex != NoPrevious)
        {
            lis.Add(sequence[maxElementIndex]);
            maxElementIndex = predecessor[maxElementIndex];
        }

        lis.Reverse();
        Console.WriteLine("subsequence = " + string.Join(", ", lis));
    }
}
