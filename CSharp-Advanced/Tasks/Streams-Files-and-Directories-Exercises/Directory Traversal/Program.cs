using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchExtension = ".";
            string path = "./";

            Dictionary<string, Dictionary<string, double>> data 
              = new Dictionary<string, Dictionary<string, double>>();

            string[] filesNames = Directory.GetFiles(path, searchPattern: $"*{searchExtension}*");

            foreach (string filePath in filesNames)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                string extension = fileInfo.Extension;
                string fileName = fileInfo.Name;
                double length = fileInfo.Length / 1024.0;

                if (!data.ContainsKey(extension))
                {
                    data.Add(extension, new Dictionary<string, double>());
                }

                data[extension].Add(fileName, length);
            }

            StringBuilder sb = new StringBuilder();

            foreach ((string extension, Dictionary<string, double> filesData) in data
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                sb.AppendLine(extension);

                foreach ((string fileName, double length) in filesData.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{fileName} - {length:F3}kb");
                }
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string resPath = Path.Combine(desktopPath, "report.txt");
            File.WriteAllText(resPath, contents: sb.ToString());
        }
    }
}
