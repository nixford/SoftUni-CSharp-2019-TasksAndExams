using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split('\\').ToArray();
            string fileName = string.Empty;
            string fileExtention = string.Empty;
            string[] output = new string[3];

            for (int i = 0; i < inputLine.Length; i++)
            {
                if (inputLine[i].Contains("."))
                {
                    output = inputLine[i].Split('.').ToArray();
                    fileName = output[0];
                    fileExtention = output[1];
                }
            }
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtention}");
        }
    }
}
