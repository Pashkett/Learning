using System;

namespace MatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstMatrix = new Matrix<int>(new int[,] { { 4, 3 }, { 2, 1 } });
            var secondMatrix = new Matrix<int>(new int[,] { { 5, 6 }, { 7, 8 } });

            Console.WriteLine("Matrices subtraction:\n");
            var matrix2 = firstMatrix - secondMatrix;
            matrix2.ShowMatrix();
        }
    }
}

