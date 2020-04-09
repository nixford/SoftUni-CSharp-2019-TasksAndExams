using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> commandsList = command.Split(' ').ToList();                
                if (commandsList[0] == "Delete")
                {
                    int currNumber = int.Parse(commandsList[1]);
                    while (numbersList.Contains(currNumber))
                    {
                        numbersList.Remove(currNumber);
                    }
                                       
                }

                if (commandsList[0] == "Insert")
                {
                    int currNumber = int.Parse(commandsList[1]);
                    int currPosition = int.Parse(commandsList[2]);
                    numbersList.Insert(currPosition, currNumber);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbersList));
        }
    }
}
