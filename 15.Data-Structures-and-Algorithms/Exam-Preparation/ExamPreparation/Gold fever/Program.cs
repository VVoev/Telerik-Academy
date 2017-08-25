using CSharpTutA.cs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTutA.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int.Parse(Console.ReadLine());
            int[] days = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Greedy(days);
        }

      
        private static void Greedy(int[] days)
        {
            long sum = 0;
            int currentMax = 0;

            for (int j = days.Length - 1; j > -1; j--)
            {
                int dayPrice = days[j];
                if (dayPrice > currentMax)
                {
                    currentMax = dayPrice;
                    continue;
                }

                sum += currentMax - dayPrice;
            }

            Console.WriteLine(sum);
        }
    }


    public abstract class Figure
    {
        public abstract double CalcSurface();
    }
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public override double CalcSurface()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
    public class Rectangle : Figure
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public override double CalcSurface()
        {
            return this.Width * this.Height;
        }
    }
    public class Square : Figure
    {
        public double Size { get; set; }

        public override double CalcSurface()
        {
            return this.Size * this.Size;
        }
    }
}
