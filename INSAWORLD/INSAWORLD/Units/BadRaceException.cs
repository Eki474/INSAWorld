using System;
using System.Runtime.Serialization;

namespace INSAWORLD
{
    [Serializable]
    public class BadRaceException : Exception
    {
        //when a proposed type (int) doesn't correspond to a true race type (Cyclops 0, Cerberus 1, Centaurs 2)

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
