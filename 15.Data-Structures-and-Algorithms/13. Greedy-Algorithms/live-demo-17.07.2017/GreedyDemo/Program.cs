using System;

namespace GreedyDemo
{
    class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var intervals = new Interval[n];
            for (int i = 0; i < n; i++)
            {
                var strs = Console.ReadLine()
                    .Split(' ');
                intervals[i] = new Interval
                {
                    Start = int.Parse(strs[0]),
                    End = int.Parse(strs[1])
                };
            }

            Array.Sort(intervals, (x, y) => x.Start.CompareTo(y.Start));

            var intervalCount = 0;
            var currentEnd = intervals[0].End;
            var intervalIndex = 0;

            for (int i = 1; i < n; i++)
            {
                if(currentEnd <= intervals[i].Start)
                {
                    ++intervalCount;
                    Console.WriteLine(intervals[intervalIndex].Start + " " + intervals[intervalIndex].End);
                    currentEnd = intervals[i].End;
                    intervalIndex = i;
                }
                else if(intervals[i].End < currentEnd)
                {
                    currentEnd = intervals[i].End;
                    intervalIndex = i;
                }
            }

            ++intervalCount;
            Console.WriteLine(intervals[intervalIndex].Start + " " + intervals[intervalIndex].End);
            Console.WriteLine(intervalCount);
        }
    }
}
