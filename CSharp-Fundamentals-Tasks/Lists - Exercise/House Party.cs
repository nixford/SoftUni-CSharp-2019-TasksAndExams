using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> outputList = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> currCommand = Console.ReadLine().Split(' ').ToList();
                string currName = currCommand[0];

                if (outputList.Contains(currName) && currCommand[2] != "not")
                {                    
                    Console.WriteLine(currName + " is already in the list!");
                }

                if (currCommand[2] != "not" && !outputList.Contains(currName))
                {
                    outputList.Add(currName);
                }

                if(currCommand[2] == "not" && !outputList.Contains(currName))
                {                    
                    Console.WriteLine(currName + " is not in the list!");
                }

                if (outputList.Contains(currName) && currCommand[2] == "not")
                {
                    while (outputList.Contains(currName))
                    {
                        outputList.Remove(currName);                       
                    }
                }                
            }
            Console.WriteLine(string.Join("\n", outputList));
        }
    }
}
