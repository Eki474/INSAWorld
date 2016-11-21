using System;

namespace INSAWORLD
{
    public class OutOfBoundException : Exception
    {
        public OutOfBoundException(string message) : base(message) { }
    }
}
