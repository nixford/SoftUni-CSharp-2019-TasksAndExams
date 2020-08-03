using P01Logger.Enums;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
            
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
           
            if (reportLevel >= this.ReportLevel)
            {
                this.Counter++;
                Console.WriteLine(this.Layout.Format, dateTime, reportLevel, message);
            }            
        }
    }
}
