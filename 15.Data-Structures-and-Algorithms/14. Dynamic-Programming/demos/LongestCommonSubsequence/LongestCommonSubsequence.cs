using System;

public static class LongestCommonSubsequence
{
    private const string FirstString = "xabcdxxexx"; // GCCCTAGCG
    private const string SecondString = "abczxxyxabcx"; // GCGCAATG

    public static void Main()
    {
        var lcsArray = LCS(FirstString, SecondString);
        Console.WriteLine("Longest common subsequence length: " + lcsArray[FirstString.Length, SecondString.Length]);
        Console.Write("Subsequence: ");
        PrintLCS(FirstString.Length, SecondString.Length, lcsArray);
        Console.WriteLine();
    }

    private static int[,] LCS(string firstString, string secondString)
    {
        var m = firstString.Length;
        var n = secondString.Length;
        var c = new int[m + 1, n + 1];

        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (firstString[i - 1] == secondString[j - 1])
                {
                    c[i, j] = c[i - 1, j - 1] + 1;
                }
                else
                {
                    c[i, j] = Math.Max(c[i, j - 1], c[i - 1, j]);
                }
            }
        }

        // Answer in c[m, n]
        return c;
    }

    private static void PrintLCS(int i, int j, int[,] c)
    {
        if (i == 0 || j == 0)
        {
            return;
        }

        if (FirstString[i - 1] == SecondString[j - 1])
        {
            PrintLCS(i - 1, j - 1, c);
            Console.Write(FirstString[i - 1]);
        }
        else if (c[i, j] == c[i - 1, j])
        {
            PrintLCS(i - 1, j, c);
        }
        else
        {
            PrintLCS(i, j - 1, c);
        }
    }
}
