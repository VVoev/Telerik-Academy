namespace ClosestPairOfPoints
{
    class ConsistentRandom
    {
        private const int Multiplier = 359;
        private const int Adder = 10037;
        private const int Modulo = 1000000007;
        private long current;

        public ConsistentRandom()
        {
            this.current = 42;
        }

        public int Next()
        {
            this.current = (this.current * Multiplier + Adder) % Modulo;
            return (int)this.current;
        }
    }
}
