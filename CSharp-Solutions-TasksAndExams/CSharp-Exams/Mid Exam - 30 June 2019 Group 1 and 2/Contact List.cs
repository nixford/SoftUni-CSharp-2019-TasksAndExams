using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> namesList = Console.ReadLine().Split(' ').ToList();
            string command = Console.ReadLine();
            List<string> commandList = new List<string>();

            while (true)
            {
                commandList = command.Split().ToList();
                if (commandList[0] == "Add")
                {
                    if (!namesList.Contains(commandList[1]))
                    {
                        namesList.Add(commandList[1]);
                    }
                    else if (int.Parse(commandList[2]) >= 0 && int.Parse(commandList[2]) < namesList.Count)
                    {
                        namesList.Insert(int.Parse(commandList[2]), commandList[1]);
                    }                    
                }

                if (commandList[0] == "Remove")
                {
                    if (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < namesList.Count)
                    {
                        namesList.RemoveAt(int.Parse(commandList[1]));
                    }
                }

                if (commandList[0] == "Export")
                {
                    if (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < namesList.Count && int.Parse(commandList[2]) > 0 && int.Parse(commandList[2]) < namesList.Count)
                    {
                        for (int i = int.Parse(commandList[1]); i < int.Parse(commandList[2]); i++)
                        {
                            Console.Write(namesList[i] + " ");
                        }
                        Console.WriteLine();
                    }
                    else if ((int.Parse(commandList[2]) >= namesList.Count || int.Parse(commandList[2]) <= 0) &&
                        (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < namesList.Count))
                    {
                        for (int i = int.Parse(commandList[1]); i < namesList.Count; i++)
                        {
                            Console.Write(namesList[i] + " ");
                        }
                        Console.WriteLine();
                    }                           
                }

                if (commandList[0] == "Print" && commandList[1] == "Normal")
                {
                    Console.WriteLine("Contacts: " + string.Join(" ", namesList));
                    break;
                }

                if (commandList[0] == "Print" && commandList[1] == "Reversed")
                {
                    namesList.Reverse();
                    Console.WriteLine("Contacts: " + string.Join(" ", namesList));
                    break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
