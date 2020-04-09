using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();           
            
            int addPeopleInNewWagon = 0;
            int currPeopleInWagon = 0;

            while (command != "end")
            {                
                List<string> listCommands = command.Split(' ').ToList();
                if (listCommands[0] == "Add")
                {
                    addPeopleInNewWagon = int.Parse(listCommands[1]);
                    wagons.Add(addPeopleInNewWagon);
                }
                else
                {
                    int wagonCounter = 0;
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int addPeople = int.Parse(command);
                        if (wagons[wagonCounter] + addPeople <= maxCapacity)
                        {
                            currPeopleInWagon = wagons[wagonCounter];
                            wagons.RemoveAt(wagonCounter);
                            wagons.Insert(wagonCounter, currPeopleInWagon + addPeople);
                            break;
                        }
                        else
                        {
                            wagonCounter++;
                        }
                    }                    
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
