using P01Logger.Enums;
using P01Logger.Loggers;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.LogFile = logFile;
        }
       
        public ILogFile LogFile { get; }        

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {      
            if (reportLevel >= this.ReportLevel)
            {
                this.Counter++;
                this.LogFile.Write(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.LogFile.Size}";
        }
    }
}
