using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.HttpElements
{
    public class HttpServerException : Exception
    {
        public HttpServerException(string message)
            : base(message)
        {

        }
    }
}
