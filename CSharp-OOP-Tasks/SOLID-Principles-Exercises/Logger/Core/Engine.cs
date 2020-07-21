using P01Logger.Enums;
using P01Logger.Factories.AppenderFactory;
using P01Logger.Loggers;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Core
{
    public class Engine
    {
        private readonly CommandInterpreter commandInterpreter;

        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                try
                {
                    string[] inputInfo = input.Split(' ');

                    if (input == "END")
                    {
                        commandInterpreter.Read(inputInfo);
                        break;
                    }

                    commandInterpreter.Read(inputInfo);
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
