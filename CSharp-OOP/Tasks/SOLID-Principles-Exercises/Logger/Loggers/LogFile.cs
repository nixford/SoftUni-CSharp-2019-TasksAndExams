using System;
using System.IO;
using System.Linq;

namespace P01Logger.Loggers
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";

        public void Write(string message)
        {
            File.AppendAllText(LogFilePath, message + Environment.NewLine);
        }

        public int Size
            => File.ReadAllText(LogFilePath)
            .Replace(" ", "")
            .Where(char.IsLetter)
            .Sum(x => x);
    }
}
