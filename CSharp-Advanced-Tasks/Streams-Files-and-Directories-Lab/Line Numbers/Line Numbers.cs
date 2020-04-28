using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("input.txt", FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(stream);
            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();

                StreamWriter writer = new StreamWriter("output.txt");
                using (writer)
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter + 1}. {line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }                
            }            
        }
    }
}
