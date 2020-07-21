using P01Logger.Enums;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }
        public IAppender[] Appenders { get; }

        public void Info(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Warning, message);
        }

        public void Error(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Error, message);
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Fatal, message);            
        }

        private void Append(string dateTime, ReportLevel error, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(dateTime, error, message);
            }
        }
    }
}
