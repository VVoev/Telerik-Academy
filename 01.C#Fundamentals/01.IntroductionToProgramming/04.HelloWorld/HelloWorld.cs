using System;
using System.Collections.Generic;
using System.Linq;

class HelloWorld
{
    static void Main()
    {
        /*
        3 4 4 5 5 5 2 2 
        7 7 4 4 5 5 3 3
        1 2 3 3
        */

        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int startIndex = 0;
        int endIndex = 0;
        int len = 0;
        int bestLen = 0;
        for (int i = 0; i < numbers.Length-1; i++)
        {
            for (int j = i+1; j < numbers.Length; j++)
            {
                int x = numbers[i];
                int y = numbers[j];
                if (numbers[i] == numbers[j] && len>=bestLen)
                {
                    startIndex = i;
                    endIndex = j;
                    len++;
                }
                else if (numbers[i] == numbers[j])
                {
                    len++;
                }
            
            }
            if (len > bestLen)
            {
                bestLen = len;
            }
            len = 0;
        }
        var list = new List<int>();
        for (int i = startIndex; i <= endIndex; i++)
        {
            list.Add(numbers[i]);
        }
        //Console.WriteLine($"Start Index:{startIndex} EndIndex:{endIndex}");
        Console.WriteLine(string.Join(" ",list));
    }
}
