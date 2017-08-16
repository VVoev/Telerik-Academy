using System;
using System.Collections.Generic;

namespace AcademyTasks
{
    public class Program
    {
        public static List<int> tasks = new List<int>();
        public static int variety;
        public static int maxIndex = -1;
        static int bestSolution = int.MaxValue;
        static void Main(string[] args)
        {
            /*
            Input	Output
            1, 2, 3
            2	        Output:2
            
            1, 2, 3, 4, 5
            3           Output:3
            
            6, 2, 6, 2, 6, 3, 3, 3, 7
            4	        Output:2
            */

            ReadInput();
            variety = int.Parse(Console.ReadLine());
            bestSolution = tasks.Count;

            int currentMin = tasks[0];
            int currentMax = tasks[0];
            for (int i = 0; i < tasks.Count; i++)
            {
                currentMin = Math.Min(tasks[i], currentMin);
                currentMax = Math.Max(tasks[i], currentMax);

                if (currentMax - currentMin >= variety)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine(tasks.Count);
                return;
            }

            //Recursive
            Solve(0, 1, tasks[0], tasks[0]);
            Console.WriteLine(bestSolution);
            //Dp
            Console.WriteLine(SolveDp());


        }

        private static int SolveDp()
        {
            int minCount = tasks.Count;
            for (int i = 0; i < tasks.Count - 1; i++)
            {
                for (int j = i + 1; j < tasks.Count; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= variety)
                    {
                        int count = 0;
                        count += (i + 1) / 2;
                        count += (j - i + 1) / 2 + 1;

                        minCount = Math.Min(minCount, count);
                    }
                }
            }
            return minCount;
        }

        public static void Solve(int currentIndex, int taskSolved, int currentMin, int currentMax)
        {
            if (currentMax - currentMin >= variety)
            {
                bestSolution = Math.Min(bestSolution, taskSolved);
                return;
            }

            if (currentIndex >= maxIndex)
            {
                return;
            }

            for (int i = 1; i <= 2; i++)
            {
                if (currentIndex + i < tasks.Count)
                {
                    Solve(currentIndex + i, taskSolved + 1,
                        Math.Min(currentMin, tasks[currentIndex + i]),
                        Math.Max(currentMax, tasks[currentIndex + i]));
                }
            }
        }
        private static void ReadInput()
        {
            string task = Console.ReadLine();
            var taskAsString = task.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in taskAsString)
            {
                tasks.Add(int.Parse(item));
            }
        }
    }
}
