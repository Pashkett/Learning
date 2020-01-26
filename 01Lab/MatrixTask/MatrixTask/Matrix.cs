using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MatrixTask
{
    class Matrix<T> : IEnumerable, ICloneable, IComparable<Matrix<T>>
        where T : struct
    {
        // Properties
        public int ElementsCount { get => MatrixBody?.Length ?? 0; }
        public int Rows { get => MatrixBody?.GetLength(0) ?? 0; }
        public int Columns { get => MatrixBody?.GetLength(1) ?? 0; }
        public T[,] MatrixBody { get; private set; }

        // Constructor
        public Matrix(T[,] matrixBody) =>
            MatrixBody = matrixBody;
        
        //Method to display matrix 
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

        #region Serialization/Deserialization
        public static void SerializeBinary(Matrix<T> matrix, string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream1 = File.Create(fileName))
            {
                formatter.Serialize(fileStream1, matrix.MatrixBody);
            }
        }

        public static Matrix<T> DeserializeBinary(string filePath)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream2 = File.Open(filePath, FileMode.Open))
            {
                return new Matrix<T>((T[,])formatter.Deserialize(fileStream2));
            }
        }

        #endregion

        #region Overloading unary "-", binary "+/-", binary "*"
        public static Matrix<T> operator -(Matrix<T> matrix1)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException("Unary \"-\" operation is not supported for matrices assigned null values.");
            }
            if (!(IsValidType(matrix1)))
            {
                throw new ArgumentException("Unary \"-\" operation is not supported for matrices of current type.");
            }
            Matrix<T> result = new Matrix<T>(new T[matrix1.Rows, matrix1.Columns]);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = SetToNegative(matrix1[i, j]);
                }
            }
            return result;
        }

        public static Matrix<T> operator + (Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException("Addition operation is not supported for matrices assigned null values.");
            }
            if (!(IsValidType(matrix1)))
            {
                throw new ArgumentException("Addition operation is not supported for matrices of current type.");
            }
            if (matrix1.Columns != matrix2.Columns || matrix1.Rows != matrix2.Rows)
            {
                throw new ArgumentException("Addition operation is not supported for matrices with different sizes.");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(new T[matrix1.Rows, matrix1.Columns]);
                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix1.Columns; j++)
                    {
                        result[i, j] = Add(matrix1[i, j], matrix2[i, j]);
                    }
                }
                return result;
            }
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {

            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException("Subtraction operation is not supported for matrices assigned null values.");
            }
            if (!(IsValidType(matrix1)))
            {
                throw new ArgumentException("Subtraction operation is not supported for matrices of current type.");
            }
            if (matrix1.Columns != matrix2.Columns || matrix1.Rows != matrix2.Rows)
            {
                throw new ArgumentException("Subtraction operation is not supported for matrices with different sizes.");
            }
            else
            {
                matrix2 = -matrix2;
                Matrix<T> result = new Matrix<T>(new T[matrix1.Rows, matrix1.Columns]);
                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix1.Columns; j++)
                    {
                        result[i, j] = Add(matrix1[i, j], matrix2[i, j]);
                    }
                }
                return result;
            }
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException("Multiplication operation is not supported for matrices assigned null values.");
            }
            if (!(IsValidType(matrix1)))
            {
                throw new ArgumentException("Multiplication operation is not supported for matrices of current type.");
            }
            if (matrix1.Columns != matrix2.Rows)
            {
                
                throw new ArgumentException("Multiplication operation is not supported for matrices when first matrix columns is not equal to second matrix rows");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(new T[matrix1.Rows, matrix2.Columns]);
                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix2.Columns; j++)
                    {
                        result[i, j] = default;
                        for (int k = 0; k < matrix1.Columns; k++)
                        {
                            result[i, j] = Add(result[i, j], Add(matrix1[i, k], matrix2[k, j]));
                        }
                    }
                }
                return result;
            }
        }
        
        #endregion

        #region Utility functions
        private static T Add(T x, T y)
        {
            dynamic dx = x;
            dynamic dy = y;
            return dx + dy;
        }
        
        private static T SetToNegative(T x)
        {
            dynamic dx = x;
            return -dx;
        }

        private static bool IsValidType(Matrix<T> matrix)
        {
            switch (matrix[0, 0])
            {
                //Is integral types
                case sbyte sb:
                case byte b:
                case short s:
                case ushort us:
                case int i:
                case uint ui:
                case long l:
                case ulong ul:
                //Floating numbers
                case float fl:
                case double d:
                case decimal dm:
                    return true;
                default:
                    return false;
            }
        }

        #endregion

        #region Indexer implementation
        public T this[int i, int j]
        {
            get => MatrixBody[i, j];
            set => MatrixBody[i, j] = value;
        }

        #endregion

        #region IEnumerable implementation
        public IEnumerator GetEnumerator()
        {
            return MatrixBody.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

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