﻿using System;

namespace INSAWORLD
{
    public class OutOfBoundException : Exception
    {
        public OutOfBoundException(string s)
        {
            base.Exception(s);
        }
    }
}
