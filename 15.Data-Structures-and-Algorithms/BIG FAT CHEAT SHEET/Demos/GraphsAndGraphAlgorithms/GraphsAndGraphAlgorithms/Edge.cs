namespace GraphsAndGraphAlgorithms
{
    public class Edge<T>
    {
        public Edge(T from, T to)
        {
            this.From = from;
            this.To = to;
        }

        public T From { get; private set; }

        public T To { get; private set; }
    }
}
