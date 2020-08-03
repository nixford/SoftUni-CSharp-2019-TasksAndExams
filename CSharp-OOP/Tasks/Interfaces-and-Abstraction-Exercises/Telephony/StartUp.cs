using System;
using System.Collections.Generic;
using System.Linq;
using Telephony.Core;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();           
        }
    }
}
