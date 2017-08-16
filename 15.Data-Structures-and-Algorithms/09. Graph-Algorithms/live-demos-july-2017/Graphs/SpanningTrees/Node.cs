namespace SpanningTrees
{
    partial class SpanningTreesDemos
    {
        class Node
        {
            public Node(int vertex, int weight)
            {
                Vertex = vertex;
                Weight = weight;
            }

            public int Vertex { get; set; }

            public int Weight { get; set; }
        }
    }
}
