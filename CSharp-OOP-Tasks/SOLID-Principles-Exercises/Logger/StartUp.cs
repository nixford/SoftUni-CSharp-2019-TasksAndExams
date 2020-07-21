using P01Logger.Appenders;
using P01Logger.Core;
using P01Logger.Enums;
using P01Logger.Layouts;
using P01Logger.Loggers;
using P01Logger.Models.Contracts;
using System;

namespace P01Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();            
        }
    }
}
