using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("text.txt", FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(stream);
            int count = 0;
            
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {                    
                    string[] inputArr = line.ToString().Split().ToArray();
                    Array.Reverse(inputArr);

                    for (int i = 0; i < inputArr.Length; i++)
                    {                        
                        char[] temp = inputArr[i].ToArray();
                        for (int j = 0; j < temp.Length; j++)
                        {
                            if (temp[j] == '-' ||
                                temp[j] == ',' ||
                                temp[j] == '.' ||
                                temp[j] == '!' ||
                                temp[j] == '?')
                            {
                                temp[j] = '@';
                            }
                        }
                        string currWord = string.Join("", temp);
                        inputArr[i] = currWord;
                    }

                    if (count % 2 == 0 || count == 0)
                    {
                        FileStream streamOutput = new FileStream("output.txt", FileMode.Append);
                        StreamWriter writer = new StreamWriter(streamOutput);
                        using (writer)
                        {
                            writer.WriteLine(string.Join(" ", inputArr));
                        }                        
                    }                    
                    line = reader.ReadLine();
                    count++;
                }
            }            
        }
    }
}
