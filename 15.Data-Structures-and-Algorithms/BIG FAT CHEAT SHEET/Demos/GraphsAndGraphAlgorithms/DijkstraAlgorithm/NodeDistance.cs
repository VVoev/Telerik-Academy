namespace DijkstraAlgorithm
{
    public class NodeDistance
    {
        public NodeDistance(string node, int distance)
        {
            this.Node = node;
            this.Distance = distance;
        }

        public string Node { get; set; }

        public int Distance { get; set; }
    }
}
