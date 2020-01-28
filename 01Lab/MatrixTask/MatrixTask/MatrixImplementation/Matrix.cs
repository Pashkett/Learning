using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;


namespace MatrixTask.MatrixImplementation
{
    public partial class Matrix<T> : IEnumerable, ICloneable, IComparable<Matrix<T>>
        where T : struct
    {
        public int ElementsCount { get => MatrixBody?.Length ?? 0; }
        public int Rows { get => MatrixBody?.GetLength(0) ?? 0; }
        public int Columns { get => MatrixBody?.GetLength(1) ?? 0; }
        public T[,] MatrixBody { get; private set; }

        public Matrix(T[,] matrixBody) =>
            MatrixBody = matrixBody;
        
        public void ShowMatrix()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    Console.Write($"{this[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        
        public override string ToString()
        {
            return base.ToString();
        }

        #region Indexer implementation
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0)
                    throw new InvalidMatrixIndexException("Matrix index should not be negative");
                else
                    return MatrixBody[i, j];
            }
            set
            {
                if (i < 0 || j < 0)
                    throw new InvalidMatrixIndexException("Matrix index should not be negative");
                else
                    MatrixBody[i, j] = value;
            }
        }

        #endregion

        #region IEnumerable implementation

        public IEnumerator Enumerator => 
            MatrixBody.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            (IEnumerator)Enumerator;

        #endregion

        #region IClonable implementation
        public object Clone()
        {
            T[,] bufferMatrix = new T[Rows, Columns];
            Array.Copy(MatrixBody, bufferMatrix, MatrixBody.Length);

            return new Matrix<T>(bufferMatrix);
        }

        #endregion

        #region IComparable implementation
        public int CompareTo([AllowNull] Matrix<T> other)
        {
            if (other == null)
                return 1;
            if (this.ElementsCount < other.ElementsCount)
                return -1;
            if (this.ElementsCount > other.ElementsCount)
                return 1;

            return 0;

        #endregion
        }
    }
}