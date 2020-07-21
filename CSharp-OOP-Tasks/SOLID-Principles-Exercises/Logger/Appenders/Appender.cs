using P01Logger.Enums;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        protected int Counter { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return 
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.Counter}";
        }
    }
}
