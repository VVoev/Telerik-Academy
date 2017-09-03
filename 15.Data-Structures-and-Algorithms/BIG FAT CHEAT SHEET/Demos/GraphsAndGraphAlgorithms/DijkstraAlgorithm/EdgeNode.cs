namespace DijkstraAlgorithm
{
    public class EdgeNode
    {
        public EdgeNode(string target, int weight)
        {
            this.Target = target;
            this.Weight = weight;
        }

        public string Target { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Target: {Target}: Weight: {Weight}";
        }
    }
}
