using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    public class Program
    {
        static int[] numbers;
        static int stopIndex;
        static int variety;

        public static void Main()
        {
            numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            variety = int.Parse(Console.ReadLine());

            stopIndex = -1;
            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                min = Math.Min(min, numbers[i]);
                max = Math.Max(max, numbers[i]);

                if (max - min >= variety)
                {
                    stopIndex = i;
                    break;
                }
            }

            if (stopIndex == -1)
            {
                Console.WriteLine(numbers.Length);
                return;
            }

            Solve(1, numbers[0], numbers[0], 0);
            Console.WriteLine(bestSolution);
        }

        static int bestSolution = int.MaxValue;

        static bool isTaskSolved = false;

        public static void Solve(int tasksSolved, int min, int max, int index)
        {
            if (index > stopIndex || isTaskSolved)
            {
                return;
            }

            var currentMax = Math.Max(max, numbers[index]);
            var currentMin = Math.Min(min, numbers[index]);

            if (currentMax - currentMin >= variety)
            {
                isTaskSolved = true;
                bestSolution = tasksSolved;
                return;
            }

            Solve(tasksSolved + 1, currentMin, currentMax, index + 2);

            if (isTaskSolved)
            {
                return;
            }

            Solve(tasksSolved + 1, currentMin, currentMax, index + 1);
        }
    }
}
