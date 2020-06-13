using Military.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
