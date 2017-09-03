namespace MinimumSpanningTree
{
    public class Node
    {
        public Node(int target, int weight)
        {
            this.Target = target;
            this.Weight = weight;
        }

        public int Target { get; set; }

        public int Weight { get; set; }
    }
}
