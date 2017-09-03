using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    public class Frame
    {
        public Frame(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }

        public void Swap()
        {
            var tmp = this.X;
            this.X = this.Y;
            this.Y = tmp;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var frames = new Frame[n];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                int x = int.Parse(line[0]);
                int y = int.Parse(line[1]);

                frames[i] = new Frame(x, y);
            }

            // FindBySwapping(frames, 0);
            // Console.WriteLine(string.Join<Frame>("\n", frames));
            Solve(0, frames, new bool[n], new Frame[n]);
            Console.WriteLine(results.Count);
            var result2 = results.ToList();
            result2.Sort();
            Console.WriteLine(string.Join("\n", result2));
        }

        static HashSet<string> results = new HashSet<string>();

        public static void Solve(int index, Frame[] frames, bool[] used, Frame[] current)
        {
            if (index >= frames.Length)
            {
                results.Add(string.Join<Frame>(" | ", current));
            }

            for (int i = 0; i < frames.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    current[index] = frames[i];
                    Solve(index + 1, frames, used, current);

                    current[index] = new Frame(current[index].Y, current[index].X);
                    Solve(index + 1, frames, used, current);

                    used[i] = false;
                }
            }
        }
    }
}