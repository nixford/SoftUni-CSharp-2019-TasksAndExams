using P01Logger.Loggers;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }

        void Info(string dateTime, string message);

        void Warning(string dateTime, string message);

        void Error(string dateTime, string message);       

        void Fatal(string dateTime, string message);

        void Critical(string dateTime, string message);

    }
}
