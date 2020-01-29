using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialsTask
{
    [Serializable]
    public class InvalidCoefficientException : Exception
    {
        public InvalidCoefficientException() { }
        public InvalidCoefficientException(string message) : base(message) { }
        public InvalidCoefficientException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCoefficientException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
