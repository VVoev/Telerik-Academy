using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConvexHull
{
    class Program
    {
        const double Epsillon = 1e-12;

        static void Main()
        {
            var rnd = new Random(42);
            var points = Enumerable.Range(0, 100000)
                .Select(x => Point.GenPoint(rnd))
                .ToArray();

            for (int i = 0; i < points.Length; ++i)
            {
                var angle = i * 2 * Math.PI / points.Length;
                points[i].X = Math.Cos(angle) * 100;
                points[i].Y = Math.Sin(angle) * 100;
            }

            //points = new Point[]
            //{
            //    new Point(0, 3),
            //    new Point(2, 2),
            //    new Point(3, 0),
            //    new Point(8, 8)
            //};

            //for (int i = 0; i < points.Length; ++i)
            //{
            //    Console.WriteLine($"{i}: {points[i].X};{points[i].Y}");
            //}

            {
                var st = new Stopwatch();
                st.Start();
                var hull = ConvexHullNaive(points);
                st.Stop();
                //Console.WriteLine(string.Join(" ", hull));
                Console.WriteLine(st.Elapsed);
            }
            {
                var st = new Stopwatch();
                st.Start();
                var hull = ConvexHullGrahamScan(points);
                st.Stop();
                //Console.WriteLine(string.Join(" ", hull));
                Console.WriteLine(st.Elapsed);
            }
            {
                var st = new Stopwatch();
                st.Start();
                var hull = ConvexHullGrahamScan2(points);
                st.Stop();
                //Console.WriteLine(string.Join(" ", hull));
                Console.WriteLine(st.Elapsed);
            }
        }

        static List<int> ConvexHullNaive(Point[] points)
        {
            var hull = new List<int>();

            var firstPoint = 0;
            for (int i = 1; i < points.Length; ++i)
            {
                if (points[firstPoint].Y > points[i].Y)
                {
                    firstPoint = i;
                }
            }

            hull.Add(firstPoint);

            var prevPoint = firstPoint;
            while (true)
            {
                var nextPoint = 0;
                if (prevPoint == 0)
                {
                    nextPoint = 1;
                }
                for (int i = nextPoint + 1; i < points.Length; ++i)
                {
                    if (i == prevPoint)
                    {
                        continue;
                    }
                    //Console.WriteLine($"comparing {prevPoint} {i} {nextPoint}");
                    var area = DirectedArea(points[prevPoint], points[i], points[nextPoint]);
                    if (area > Epsillon)
                    {
                        nextPoint = i;
                    }
                }

                if (nextPoint == firstPoint)
                {
                    break;
                }
                hull.Add(nextPoint);
                prevPoint = nextPoint;
            }

            return hull;
        }

        static ListDualStack<int> ConvexHullGrahamScan(Point[] points)
        {
            var hull = new ListDualStack<int>();

            var firstIndex = 0;
            for (int i = 1; i < points.Length; ++i)
            {
                if (points[firstIndex].Y > points[i].Y)
                {
                    firstIndex = i;
                }
            }
            hull.Add(firstIndex);
            var firstPoint = points[firstIndex];

            var sortedPoints = new int[points.Length - 1];
            for (int i = 0; i < sortedPoints.Length; ++i)
            {
                if (i == firstIndex)
                {
                    sortedPoints[i] = points.Length - 1;
                }
                else
                {
                    sortedPoints[i] = i;
                }
            }

            Array.Sort(sortedPoints, (ia, ib) =>
                {
                    var a = points[ia];
                    var b = points[ib];
                    var area = DirectedArea(firstPoint, a, b);
                    if (area < -Epsillon)
                    {
                        return 1;
                    }
                    if (area > Epsillon)
                    {
                        return -1;
                    }
                    return 0;
                });

            hull.Add(sortedPoints[0]);

            for (int i = 1; i < sortedPoints.Length; ++i)
            {
                var currIndex = sortedPoints[i];

                while (true)
                {
                    var area = DirectedArea(
                        points[hull.SecondLast],
                        points[hull.Last],
                        points[currIndex]);

                    if (area > Epsillon)
                    {
                        break;
                    }
                    hull.RemoveLast();
                }
                hull.Add(currIndex);
            }

            while (true)
            {
                var area = DirectedArea(
                    points[hull.SecondLast],
                    points[hull.Last],
                    points[hull.First]);

                if (area > Epsillon)
                {
                    break;
                }
                hull.RemoveLast();
            }

            return hull;
        }

        static ListDualStack<int> ConvexHullGrahamScan2(Point[] points)
        {
            var hull = new ListDualStack<int>();

            var sortedIndeces = Enumerable.Range(0, points.Length)
                .OrderBy(x => points[x].Y)
                .ToArray();

            hull.Add(sortedIndeces[0]);
            hull.Add(sortedIndeces[1]);

            for (int i = 2; i < sortedIndeces.Length; ++i)
            {
                while (hull.Count > 1)
                {
                    var area = DirectedArea(
                        points[hull.SecondLast],
                        points[hull.Last],
                        points[sortedIndeces[i]]);

                    if (area > Epsillon)
                    {
                        break;
                    }

                    hull.RemoveLast();
                }

                hull.Add(sortedIndeces[i]);
            }
            for (int i = sortedIndeces.Length - 2; i >= 0; --i)
            {
                while (hull.Count > 1)
                {
                    var area = DirectedArea(
                        points[hull.SecondLast],
                        points[hull.Last],
                        points[sortedIndeces[i]]);

                    if (area > Epsillon)
                    {
                        break;
                    }

                    hull.RemoveLast();
                }

                hull.Add(sortedIndeces[i]);
            }
            hull.RemoveLast();

            return hull;
        }

        static double DirectedArea(Point a, Point b, Point c)
        {
            return a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);
        }
    }
}
