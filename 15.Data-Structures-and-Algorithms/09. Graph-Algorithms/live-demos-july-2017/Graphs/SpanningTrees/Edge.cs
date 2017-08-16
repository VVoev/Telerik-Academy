using System;

namespace SpanningTrees
{
    partial class SpanningTreesDemos
    {
        class Edge
            : IComparable<Edge>
        {
            public Edge(int x, int y, int weight)
            {
                X = x;
                Y = y;
                Weight = weight;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Weight { get; set; }

            public int CompareTo(Edge other)
            {
                return this.Weight.CompareTo(other.Weight);
            }

            public override string ToString()
            {
                return $"{this.X} -> {this.Y} ({this.Weight})";
            }
        }
    }
}
