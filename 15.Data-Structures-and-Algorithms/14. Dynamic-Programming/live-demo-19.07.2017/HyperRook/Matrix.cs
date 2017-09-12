namespace HyperRook
{
    class Matrix
    {
        private int n;
        private int mod;
        public int[,] Table { get; private set; }

        public Matrix(int n, int mod)
        {
            this.n = n;
            this.mod = mod;
            this.Table = new int[n, n];
        }

        public Matrix MultiplyTo(Matrix other)
        {
            var result = new Matrix(this.n, this.mod);

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    result.Table[i, j] = 0;
                    for (int k = 0; k < n; ++k)
                    {
                        var x = (long)this.Table[i, k] * other.Table[k, j];
                        var y = (x + result.Table[i, j]) % this.mod;
                        result.Table[i, j] = (int)y;
                    }
                }
            }

            return result;
        }

        public Matrix Square()
        {
            return this.MultiplyTo(this);
        }

        public Matrix FastPower(int p)
        {
            if (p == 0)
            {
                var oneM = new Matrix(this.n, this.mod);
                for (int i = 0; i < this.n; ++i)
                {
                    oneM.Table[i, i] = 1;
                }
                return oneM;
            }

            if (p % 2 > 0)
            {
                return this.MultiplyTo(this.FastPower(p - 1));
            }

            return this.FastPower(p / 2).Square();
        }
    }
}
