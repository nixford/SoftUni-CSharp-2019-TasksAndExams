using P01Logger.Appenders;
using P01Logger.Enums;
using P01Logger.Loggers;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Factories.AppenderFactory
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {

            string appenderType = type.ToLower();

            switch (appenderType)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout) { ReportLevel = reportLevel };
                case "fileappender":
                    return new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel };
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }
        }
    }
}
