using System;
using System.Runtime.Serialization;

namespace INSAWORLD
{
    [Serializable]
    public class BadTypeException : Exception
    {
        //when a proposed type (int) doesn't correspond to a true tile type (Plain 0, Swamp 1, Volcano 2, Desert 3)
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