using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Core
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
