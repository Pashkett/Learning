using System;

namespace MatrixTask.MatrixImplementation
{
    public partial class Matrix<T> : ICloneable, IComparable<Matrix<T>>
        where T : struct
    {
        #region Overloading unary "-", binary "+/-", binary "*"
        public static Matrix<T> operator -(Matrix<T> matrix1)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException("Unary \"-\" operation is not supported for matrices assigned null values.");
            }
            if (MatrixUtils<T>.IsNotValidType(matrix1))
            {
                throw new ArgumentException("Unary \"-\" operation is not supported for matrices of current type.");
            }
            Matrix<T> result = new Matrix<T>(new T[matrix1.Rows, matrix1.Columns]);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = MatrixUtils<T>.SetElementToNegative(matrix1[i, j]);
                }
            }
            return result;
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException("Addition operation is not supported for matrices assigned null values.");
            }
            if (MatrixUtils<T>.IsNotValidType(matrix1) || MatrixUtils<T>.IsNotValidType(matrix2))
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
                        result[i, j] = MatrixUtils<T>.AddMatrixElement(matrix1[i, j], matrix2[i, j]);
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
            if (MatrixUtils<T>.IsNotValidType(matrix1) || MatrixUtils<T>.IsNotValidType(matrix2))
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
                        result[i, j] = MatrixUtils<T>.AddMatrixElement(matrix1[i, j], matrix2[i, j]);
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
            if (MatrixUtils<T>.IsNotValidType(matrix1) || MatrixUtils<T>.IsNotValidType(matrix2))
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
                            result[i, j] = MatrixUtils<T>.AddMatrixElement(
                                result[i, j],
                                MatrixUtils<T>.AddMatrixElement(matrix1[i, k], matrix2[k, j]));
                        }
                    }
                }

                return result;
            }
        }

        #endregion
    }
}
