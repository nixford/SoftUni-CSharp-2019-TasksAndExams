using P01Logger.Enums;
using P01Logger.Factories.AppenderFactory;
using P01Logger.Loggers;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Core
{
    public class CommandInterpreter
    {
        private readonly List<IAppender> appenders;
        private ILogger logger;
        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
        }

        //ILogger logger = new Logger(appenders.ToArray());

        public void Read(string[] args)
        {
            string command = args[0];

            if (command == "Create")
            {
                CreateAppender(args);
            }
            else if (command == "Append")
            {
                logger = new Logger(appenders.ToArray());
                AppendMessage(args);
            }
            else if (command == "END")
            {
                PrintInfo();
            }
        }

        private void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var item in appenders)
            {
                Console.WriteLine(item);
            }
        }
        private void CreateAppender(string[] inputInfo)
        {
            string appenderType = inputInfo[1];
            string layoutType = inputInfo[2];
            ReportLevel reportLevel = ReportLevel.Info;

            if (inputInfo.Length > 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(inputInfo[3], true);
            }

            ILayout layout = LayoutFactory.CreateLayout(layoutType);
            IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
            appenders.Add(appender);
        }
        private void AppendMessage(string[] inputInfo)
        {
            string loggerMethodType = inputInfo[1];
            string date = inputInfo[2];
            string message = inputInfo[3];

            if (loggerMethodType == "INFO")
            {
                logger.Info(date, message);
            }
            else if (loggerMethodType == "WARNING")
            {
                logger.Warning(date, message);
            }
            else if (loggerMethodType == "ERROR")
            {
                logger.Error(date, message);
            }
            else if (loggerMethodType == "CRITICAL")
            {
                logger.Critical(date, message);
            }
            else if (loggerMethodType == "FATAL")
            {
                logger.Fatal(date, message);
            }
        }        
    }
}
