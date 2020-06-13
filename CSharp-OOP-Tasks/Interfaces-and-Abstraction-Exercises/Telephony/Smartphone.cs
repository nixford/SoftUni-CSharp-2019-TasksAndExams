using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exceptions;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {        
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }
            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidUrlException();
            }
             
            return $"Browsing: {url}!";
        }
    }
}
