using Military.Core;
using Military.Core.Contracts;
using Military.IO;
using Military.IO.Contracts;
using System;

namespace Military
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter write = new ConsoleWriter();

            IEngine engine = new Engine(reader, write);

            engine.Run();
        }
    }
}
