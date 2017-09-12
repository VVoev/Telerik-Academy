using System;
using System.Diagnostics;
using System.Linq;

namespace ClosestPairOfPoints
{
    class Program
    {
        private const double Epsillon = 1e-12;

        static void Main()
        {
            var rnd = new ConsistentRandom();
            var points = Enumerable.Range(0, 100000)
                .Select(x => Point.GenPoint(rnd))
                //.Select(p =>
                //{
                //    p.X = 1;
                //    return p;
                //})
                .ToArray();

            {
                var st = new Stopwatch();
                st.Start();
                var tuple = FindClosestPairNaive(points);
                st.Stop();
                var distance = points[tuple.Item1].DistanceTo(points[tuple.Item2]);
                Console.WriteLine($"{tuple.Item1} {tuple.Item2} {distance}");
                Console.WriteLine($"Naive: {st.Elapsed}");
            }
            {
                var st = new Stopwatch();
                st.Start();
                var tuple = FindClosestPairDivideConquer(points);
                st.Stop();
                var distance = points[tuple.Item1].DistanceTo(points[tuple.Item2]);
                Console.WriteLine($"{tuple.Item1} {tuple.Item2} {distance}");
                Console.WriteLine($"DivConq: {st.Elapsed}");
            }
        }

        static Tuple<int, int> FindClosestPairNaive(Point[] points)
        {
            var best1 = 0;
            var best2 = 1;
            var bestDistance = points[0].DistanceToSquared(points[1]);

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    var currentDistance = points[i].DistanceToSquared(points[j]);
                    if (bestDistance > currentDistance)
                    {
                        bestDistance = currentDistance;
                        best1 = i;
                        best2 = j;
                    }
                }
            }

            return new Tuple<int, int>(best1, best2);
        }

        static Tuple<int, int> FindClosestPairDivideConquer(Point[] points)
        {
            Array.Sort(points, Point.XComparer);
            return FindClosestPairDivideConquer(points, 0, points.Length);
        }

        static Tuple<int, int> FindClosestPairDivideConquer(Point[] points, int begin, int end)
        {
            if (end - begin == 2)
            {
                return new Tuple<int, int>(begin, begin + 1);
            }
            if (end - begin < 2)
            {
                return null;
            }

            var middle = (begin + end) / 2;
            var leftResult = FindClosestPairDivideConquer(points, begin, middle);
            var rightResult = FindClosestPairDivideConquer(points, middle, end);

            var leftDistance = leftResult == null
                ? 1e15
                : points[leftResult.Item1].DistanceTo(points[leftResult.Item2]);
            var rightDistance = rightResult == null
                ? 1e15
                : points[rightResult.Item1].DistanceTo(points[rightResult.Item2]);

            var bestDistance = leftDistance < rightDistance
                ? leftDistance
                : rightDistance;

            var bestPair = leftDistance < rightDistance
                ? leftResult
                : rightResult;

            var borderMiddle = points[middle].X;
            var borderLeft = borderMiddle - bestDistance;
            var borderRight = borderMiddle + bestDistance;

            var borderLeftIndex = FindPointX(points, begin, middle, borderLeft);
            var borderRightIndex = FindPointX(points, middle, end, borderRight);

            var leftPoints = Enumerable.Range(borderLeftIndex, middle - borderLeftIndex)
                .OrderBy(ind => points[ind].Y)
                .ToArray();

            var rightPoints = Enumerable.Range(middle, borderRightIndex - middle)
                .OrderBy(ind => points[ind].Y)
                .ToArray();

            for (int i = 0, j = 0; i < leftPoints.Length; ++i)
            {
                var yBottomLine = points[leftPoints[i]].Y - bestDistance;
                var yTopLine = points[leftPoints[i]].Y + bestDistance;

                while (j < rightPoints.Length && points[rightPoints[j]].Y < yBottomLine - Epsillon)
                {
                    ++j;
                }

                if(j >= rightPoints.Length)
                {
                    break;
                }

                for(int k = j; k < rightPoints.Length; ++k)
                {
                    if (points[rightPoints[k]].Y > yTopLine + Epsillon)
                    {
                        break;
                    }

                    var currentDistance = points[leftPoints[i]].DistanceTo(points[rightPoints[k]]);
                    if (bestDistance > currentDistance)
                    {
                        bestDistance = currentDistance;
                        bestPair = new Tuple<int, int>(leftPoints[i], rightPoints[k]);
                        yTopLine = points[leftPoints[i]].Y + bestDistance;
                    }
                }
            }

            return bestPair;
        }

        static int FindPointX(Point[] points, int left, int right, double x)
        {
            while (left < right)
            {
                int middle = (left + right) / 2;
                if (points[middle].X < x)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }
    }
}
