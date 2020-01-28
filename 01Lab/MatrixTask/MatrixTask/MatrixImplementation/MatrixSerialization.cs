using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MatrixTask.MatrixImplementation
{
    public static class MatrixSerialization<T> where T : struct
    {
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
    }
}
