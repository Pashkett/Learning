using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixTask.MatrixImplementation
{

    [Serializable]
    public class InvalidMatrixIndexException : Exception
    {
        public InvalidMatrixIndexException() { }
        public InvalidMatrixIndexException(string message) : base(message) { }
        public InvalidMatrixIndexException(string message, Exception inner) : base(message, inner) { }
        protected InvalidMatrixIndexException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
