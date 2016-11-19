using System;

namespace INSAWORLD
{
    public class BadRaceException : Exception
    {

        public BadRaceException(string s)
        {
            base.Exception(s);
        }

    }
}
