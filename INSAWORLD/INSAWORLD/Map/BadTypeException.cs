using System;
using System.Runtime.Serialization;

namespace INSAWORLD
{
    [Serializable]
    public class BadTypeException : Exception
    {
        public BadTypeException()
        {
        }

        public BadTypeException(string message) : base(message)
        {
        }

        public BadTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}