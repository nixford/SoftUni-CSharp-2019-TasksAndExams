using Raiding.Core;
using Raiding.HeroSchool;
using Raiding.IO;
using System;


namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        
        {
            IReader reader = new ConsoleReader(); // FileReader();
            IWriter writer = new ConsoleWriter();
            IHeroSchool heroSchool = new HeroShool();

            Engine engine = new Engine(reader, writer, heroSchool);
            engine.Run();
        }
    }
}
