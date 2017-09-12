namespace Fibonacci
{
    class Matrix22
    {
        private long[,] matrix = new long[2, 2];

        public long UpperLeftCorner => this.matrix[0, 0];

        public Matrix22(int a, int b, int c, int d)
        {
            this.matrix[0, 0] = a;
            this.matrix[0, 1] = b;
            this.matrix[1, 0] = c;
            this.matrix[1, 1] = d;
        }

        public override string ToString()
        {
            return $@"{this.matrix[0, 0]} {this.matrix[0, 1]}
{this.matrix[1, 0]} {this.matrix[1, 1]}";
        }

        public Matrix22 MultiplyTo(Matrix22 other)
        {
            var result = new Matrix22(0, 0, 0, 0);

            result.matrix[0, 0] = this.matrix[0, 0] * other.matrix[0, 0]
                                + this.matrix[0, 1] * other.matrix[1, 0];

            result.matrix[0, 1] = this.matrix[0, 0] * other.matrix[0, 1]
                                + this.matrix[0, 1] * other.matrix[1, 1];

            result.matrix[1, 0] = this.matrix[1, 0] * other.matrix[0, 0]
                                + this.matrix[1, 1] * other.matrix[1, 0];

            result.matrix[1, 1] = this.matrix[1, 0] * other.matrix[0, 1]
                                + this.matrix[1, 1] * other.matrix[1, 1];

            return result;
        }

        public Matrix22 ModDivide(long mod)
        {
            this.matrix[0, 0] %= mod;
            this.matrix[0, 1] %= mod;
            this.matrix[1, 0] %= mod;
            this.matrix[1, 1] %= mod;
            return this;
        }

        public Matrix22 Square()
        {
            return this.MultiplyTo(this);
        }
    }
}
