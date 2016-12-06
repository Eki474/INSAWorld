using System;
using System.Runtime.Serialization;

namespace INSAWORLD
{
    [Serializable]
    public class BadMapException : Exception
    {
        public BadMapException()
        {
        }

        public BadMapException(string message) : base(message)
        {
        }

        public BadMapException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadMapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}