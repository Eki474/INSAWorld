using System;
using System.Runtime.Serialization;

namespace INSAWORLD
{
    [Serializable]
    public class BadRaceException : Exception
    {

        public BadRaceException()
        {
        }

        public BadRaceException(string message) : base(message)
        {
        }

        public BadRaceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadRaceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
