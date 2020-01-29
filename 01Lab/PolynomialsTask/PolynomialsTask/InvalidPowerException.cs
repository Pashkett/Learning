using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialsTask
{
    [Serializable]
    public class InvalidPowerException : Exception
    {
        public InvalidPowerException() { }
        public InvalidPowerException(string message) : base(message) { }
        public InvalidPowerException(string message, Exception inner) : base(message, inner) { }
        protected InvalidPowerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
