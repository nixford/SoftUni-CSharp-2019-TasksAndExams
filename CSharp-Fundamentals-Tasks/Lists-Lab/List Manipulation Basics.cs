using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split(' ').ToList();
            List<string> command = Console.ReadLine().Split(' ').ToList();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    inputList.Add(command[1]);
                }
                else if (command[0] == "Remove")
                {
                    inputList.Remove(command[1]);
                }
                else if (command[0] == "RemoveAt")
                {
                    inputList.RemoveAt(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    inputList.Insert(int.Parse(command[2]), command[1]);
                }
                command = Console.ReadLine().Split(' ').ToList();
            }
            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
