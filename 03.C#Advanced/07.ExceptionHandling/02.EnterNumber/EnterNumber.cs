using System;
using System.Collections.Generic;

class EnterNumber
{
    static List<int> listNum;

    static void Main()
    {
        int start = 1;
        int end = 100;

        ReadNumber(start, end);

        CheckIncreasingSequence(start, end);

    }

    static void ReadNumber(int start, int end)
    {

        listNum = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            listNum.Add(int.Parse(Console.ReadLine()));

        }
    }

    static void CheckIncreasingSequence(int start, int end)
    {
        try
        {
            for (int i = 0; i < 9; i++)
            {
                if (listNum[i] < start || listNum[i] > end)
                {
                    throw new ArgumentException();
                }
                if (listNum[i] >= listNum[i + 1])
                {
                    throw new ArgumentException();
                }
            }
            if (listNum[9] < start || listNum[9] > end)
            {
                throw new ArgumentException();
            }
            // If no exception found print sequence in described format.
            PrintSequence(listNum, start, end);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Exception");
        }
    }

    static void PrintSequence(List<int> list, int start, int end)
    {
        Console.WriteLine(start + " < " + string.Join(" < ", list) + " < " + end);
    }
}