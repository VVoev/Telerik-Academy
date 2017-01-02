namespace _03.Matrix
{
    using System;
    using System.Text;

    public class GenericMatrix<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        // Fields.
        private readonly T[,] matrixField;
        private int row;
        private int col;

        // Properties.
        public int Row
        {
            get { return this.row; }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Row can't be negative.");
                }
                this.row = value;
            }
        }
        public int Col
        {
            get { return this.col; }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Col can't be negative.");
                }
                this.col = value;
            }
        }

        // Indexer.
        public T this[int row, int col]
        {
            get
            {
                if ((row < 0 || row >= this.Row) && (col < 0 || col >= this.Col))
                {
                    throw new IndexOutOfRangeException("Index of matrix is out of range.");
                }
                return this.matrixField[row, col];
            }
            set
            {
                if ((row < 0 || row >= this.Row) && (col < 0 || col >= this.Col))
                {
                    throw new IndexOutOfRangeException("Index of matrix is out of range.");
                }
                else
                {
                    this.matrixField[row, col] = value;
                }
            }
        }

        // Constructor.
        public GenericMatrix(int row, int col)
        {
            if (row < 0)
            {
                throw new IndexOutOfRangeException("Index in first dimension must positive integer.");
            }
            else if (col < 0)
            {
                throw new IndexOutOfRangeException("Index in second dimension must positive integer.");
            }
            else
            {
                this.Row = row;
                this.Col = col;
                this.matrixField = new T[row, col];
            }
        }

        // Predefine operators +, -, *, true, false.
        public static GenericMatrix<T> operator +(GenericMatrix<T> firstMatrix, GenericMatrix<T> secondMatrix)
        {
            if (CheckOutsideBoundaries(firstMatrix, secondMatrix))
            {
                throw new ArithmeticException("Dimensions of the two matrices must be with same size");
            }
            GenericMatrix<T> additionMatrix = new GenericMatrix<T>(firstMatrix.Row, firstMatrix.Col);
            for (int r = 0; r < firstMatrix.Row; r++)
            {
                for (int c = 0; c < firstMatrix.Col; c++)
                {
                    additionMatrix[r, c] = (dynamic)firstMatrix[r, c] + secondMatrix[r, c];
                }
            }
            return additionMatrix;
        }
        public static GenericMatrix<T> operator -(GenericMatrix<T> firstMatrix, GenericMatrix<T> secondMatrix)
        {
            if (CheckOutsideBoundaries(firstMatrix, secondMatrix))
            {
                throw new ArithmeticException("Dimensions of the two matrices must be with same size");
            }
            GenericMatrix<T> additionMatrix = new GenericMatrix<T>(firstMatrix.Row, firstMatrix.Col);
            for (int r = 0; r < firstMatrix.Row; r++)
            {
                for (int c = 0; c < firstMatrix.Col; c++)
                {
                    additionMatrix[r, c] = (dynamic)firstMatrix[r, c] - secondMatrix[r, c];
                }
            }
            return additionMatrix;
        }
        public static GenericMatrix<T> operator *(GenericMatrix<T> firstMatrix, GenericMatrix<T> secondMatrix)
        {
            if (CheckOutsideBoundaries(firstMatrix, secondMatrix))
            {
                throw new ArithmeticException("Dimensions of the two matrices must be with equal");
            }
            GenericMatrix<T> additionMatrix = new GenericMatrix<T>(firstMatrix.Row, firstMatrix.Col);
            for (int r = 0; r < firstMatrix.Row; r++)
            {
                for (int c = 0; c < firstMatrix.Col; c++)
                {
                    additionMatrix[r, c] = (dynamic)firstMatrix[r, c] * secondMatrix[r, c];
                }
            }
            return additionMatrix;
        }
        public static bool operator true(GenericMatrix<T> matrix)
        {
            bool hasMatrixNonZeroElement = false;
            for (int r = 0; r < matrix.Row; r++)
            {
                for (int c = 0; c < matrix.Col; c++)
                {
                    if ((dynamic)matrix[r, c] == 0)
                    {
                        hasMatrixNonZeroElement = true;
                        return hasMatrixNonZeroElement;
                    }
                }
            }
            return hasMatrixNonZeroElement;
        }
        public static bool operator false(GenericMatrix<T> matrix)
        {
            bool hasMatrixNonZeroElement = false;
            for (int r = 0; r < matrix.Row; r++)
            {
                for (int c = 0; c < matrix.Col; c++)
                {
                    if ((dynamic)matrix[r, c] == 0)
                    {
                        hasMatrixNonZeroElement = true;
                        return hasMatrixNonZeroElement;
                    }
                }
            }
            return hasMatrixNonZeroElement;
        }
        
        // Methods.
        private static bool CheckOutsideBoundaries(GenericMatrix<T> firstMatrix, GenericMatrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Row || firstMatrix.Col != secondMatrix.Col)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int r = 0; r < this.Row; r++)
            {
                for (int c = 0; c < this.Col; c++)
                {
                    sb.Append(matrixField[r, c] + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
