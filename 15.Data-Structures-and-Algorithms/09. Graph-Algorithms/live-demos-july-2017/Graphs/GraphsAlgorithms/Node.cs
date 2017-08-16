using System;

namespace GraphsAlgorithms
{
    class Node : IComparable<Node>
    {
        public Node(int vertex, int distance)
        {
            Vertex = vertex;
            Distance = distance;
        }

        public int Vertex { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }
}
