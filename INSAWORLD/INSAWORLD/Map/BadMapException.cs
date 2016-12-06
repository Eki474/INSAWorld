using System;
using System.Runtime.Serialization;

namespace INSAWORLD
{
    [Serializable]
    public class BadMapException : Exception
    {
        //when a proposed type (int) doesn't correspond to a true type map (Demo 0, Small 1, Standard 2)

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