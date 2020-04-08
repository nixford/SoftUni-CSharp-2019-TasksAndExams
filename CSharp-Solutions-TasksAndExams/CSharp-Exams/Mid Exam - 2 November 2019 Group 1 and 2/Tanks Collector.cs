using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tankList = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();
            int commandNumbers = int.Parse(Console.ReadLine());            

            for (int i = 0; i < commandNumbers; i++)
            {
                string commands = Console.ReadLine();
                List<string> commandList = commands.Split(',').Select(a => a.Trim()).ToList();
                string currCommand = commandList[0];

                if (currCommand == "Add")
                {
                    string tankName = commandList[1];
                    if (tankList.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                    else
                    {
                        Console.WriteLine("Tank successfully bought");
                        tankList.Add(tankName);
                    }
                }

                if (currCommand == "Remove")
                {
                    string tankName = commandList[1];
                    if (tankList.Contains(tankName))
                    {
                        Console.WriteLine("Tank successfully sold");
                        tankList.Remove(tankName);
                    }
                    else
                    {
                        Console.WriteLine("Tank not found");                        
                    }
                }

                if (currCommand == "Remove At")
                {
                    int index = int.Parse(commandList[1]);
                    if (index >= 0 && index < tankList.Count)
                    {
                        Console.WriteLine("Tank successfully sold");
                        tankList.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }

                if (currCommand == "Insert")
                {
                    int index = int.Parse(commandList[1]);
                    string tankName = commandList[2];
                    if (index >= 0 && index < tankList.Count)
                    {
                        if (!tankList.Contains(tankName))
                        {
                            Console.WriteLine("Tank successfully bought");
                            tankList.Insert(index, tankName);
                        }
                        else
                        {
                            Console.WriteLine("Tank is already bought");
                        }                        
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
            }
            Console.WriteLine(string.Join(", ", tankList));
        }
    }
}
