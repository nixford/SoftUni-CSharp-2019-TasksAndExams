using System;
using WildFarm.Core;
using WildFarm.IO;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader(); // FileReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
