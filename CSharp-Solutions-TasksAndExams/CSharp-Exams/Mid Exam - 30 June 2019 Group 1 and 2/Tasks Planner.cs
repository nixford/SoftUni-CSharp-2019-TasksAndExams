using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> timeForEachTask = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            string command = Console.ReadLine();
            List<string> commandsSeparated = new List<string>();
            double completedTasks = 0;
            double incompletedTasks = 0;
            double droppedTasks = 0;
            List<double> incompletedTasksList = new List<double>();

            while (command != "End")
            {
                commandsSeparated = command.Split().ToList();
                if (commandsSeparated[0] == "Complete")
                {
                    if (int.Parse(commandsSeparated[1]) >= 0 && int.Parse(commandsSeparated[1]) < timeForEachTask.Count)
                    {
                        timeForEachTask.RemoveAt(int.Parse(commandsSeparated[1]));
                        timeForEachTask.Insert(int.Parse(commandsSeparated[1]), 0);
                    }                    
                }
                if (commandsSeparated[0] == "Change")
                {
                    if (int.Parse(commandsSeparated[1]) >= 0 && int.Parse(commandsSeparated[1]) < timeForEachTask.Count)
                    {
                        timeForEachTask.RemoveAt(int.Parse(commandsSeparated[1]));
                        timeForEachTask.Insert(int.Parse(commandsSeparated[1]), int.Parse(commandsSeparated[2]));
                    }
                }
                if (commandsSeparated[0] == "Drop")
                {
                    if (int.Parse(commandsSeparated[1]) >= 0 && int.Parse(commandsSeparated[1]) < timeForEachTask.Count)
                    {
                        timeForEachTask.RemoveAt(int.Parse(commandsSeparated[1]));
                        timeForEachTask.Insert(int.Parse(commandsSeparated[1]), -1);
                    }
                }
                if (commandsSeparated[0] == "Count" && commandsSeparated[1] == "Completed")
                {
                    foreach (var item in timeForEachTask)
                    {
                        if (item == 0)
                        {
                            completedTasks++;
                        }
                    }
                    Console.WriteLine(completedTasks);
                }
                if (commandsSeparated[0] == "Count" && commandsSeparated[1] == "Incomplete")
                {
                    foreach (var item in timeForEachTask)
                    {
                        if (item > 0)
                        {
                            incompletedTasks++;                            
                        }                        
                    }
                    Console.WriteLine(incompletedTasks);
                }
                if (commandsSeparated[0] == "Count" && commandsSeparated[1] == "Dropped")
                {
                    foreach (var item in timeForEachTask)
                    {
                        if (item < 0)
                        {
                            droppedTasks++;
                        }
                    }
                    Console.WriteLine(droppedTasks);
                }
                command = Console.ReadLine();                               
            }
            foreach (var item in timeForEachTask)
            {
                if (item > 0)
                {                    
                    incompletedTasksList.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", incompletedTasksList));
        }
    }
}
