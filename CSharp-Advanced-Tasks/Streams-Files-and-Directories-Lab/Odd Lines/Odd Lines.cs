using System;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("Input.txt", FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(stream);

            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();

                StreamWriter writer = new StreamWriter("Output.txt");

                using (writer)
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                    
                }
            }
        }
    }
}
