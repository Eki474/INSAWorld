using System;
using System.Runtime.Serialization;

namespace INSAWORLD
{
    [Serializable]
    public class OutOfBoundException : Exception
    {
        //when something go off map

        public OutOfBoundException()
        {
        }

        public OutOfBoundException(string message) : base(message)
        {
        }

        public OutOfBoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfBoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
