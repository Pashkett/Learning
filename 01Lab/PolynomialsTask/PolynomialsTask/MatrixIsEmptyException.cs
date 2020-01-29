using System;

namespace PolynomialsTask
{
    [Serializable]
    public class MatrixIsEmptyException : Exception
    {
        public MatrixIsEmptyException() { }
        public MatrixIsEmptyException(string message) : base(message) { }
        public MatrixIsEmptyException(string message, Exception inner) : base(message, inner) { }
        protected MatrixIsEmptyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
