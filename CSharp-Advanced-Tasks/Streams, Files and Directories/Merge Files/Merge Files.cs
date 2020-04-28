using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream streamFirst = new FileStream("Input1.txt", FileMode.OpenOrCreate);
            StreamReader readerInputFirst = new StreamReader(streamFirst);
            Queue<string> inputOne = new Queue<string>();

            using (readerInputFirst)
            {
                string line = readerInputFirst.ReadLine();
                while (line != null && line != string.Empty)
                {
                    inputOne.Enqueue(line);
                    line = readerInputFirst.ReadLine();
                }
            }

            FileStream streamSecond = new FileStream("Input2.txt", FileMode.OpenOrCreate);
            StreamReader readerInputSecond = new StreamReader(streamSecond);
            Queue<string> inputTwo = new Queue<string>();

            using (readerInputSecond)
            {
                string line = readerInputSecond.ReadLine();
                while (line != null && line != string.Empty)
                {
                    inputTwo.Enqueue(line);
                    line = readerInputSecond.ReadLine();
                }
            }

            StreamWriter writer = new StreamWriter("Output.txt");

            using (writer)
            {
                while (inputOne.Any() || inputTwo.Any())
                {
                    if (inputOne.Any())
                    {
                        writer.WriteLine(inputOne.Dequeue());
                    }
                    if (inputTwo.Any())
                    {
                        writer.WriteLine(inputTwo.Dequeue());
                    }
                }
            }
        }
    }
}
