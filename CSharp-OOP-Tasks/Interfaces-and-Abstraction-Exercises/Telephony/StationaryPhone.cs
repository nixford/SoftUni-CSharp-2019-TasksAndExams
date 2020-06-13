using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exceptions;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {

        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }
            return $"Dialing... {phoneNumber}";
        }
    }
}
