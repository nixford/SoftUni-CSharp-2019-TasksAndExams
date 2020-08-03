using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string DEF_EXC_MSG = "Invalid corps!";
        public InvalidCorpsException()
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
    }
}
