using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tubes
{
    class Tubes
    {
        static void Main(string[] args)
        {
            int martoPipes = int.Parse(Console.ReadLine());
            int neededPipes = int.Parse(Console.ReadLine());
            int[] tubes = new int[martoPipes];

            int left = 0;int mid = 0;int right = 0;

            for (int i = 0; i < martoPipes; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                if (right < tubes[i])
                    right = tubes[i];
            }

            mid = (left + right) / 2;
            int maxTube = -1, possiblePipes = 0;
            while (left <= right)
            {
                possiblePipes = 0;
                for (int i = 0; i < martoPipes; i++)
                {
                    possiblePipes += tubes[i] / mid;
                }
                if (possiblePipes >= neededPipes)
                {
                    left = mid + 1;
                    maxTube = mid;
                }
                else
                {
                    right = mid - 1;
                }
                mid = (left + right) / 2;
            }
            Console.WriteLine(maxTube);
        }
    }
}