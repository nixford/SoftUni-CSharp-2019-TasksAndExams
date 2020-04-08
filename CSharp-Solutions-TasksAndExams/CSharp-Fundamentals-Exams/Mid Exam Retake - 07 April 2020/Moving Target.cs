using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commandLine = commands.Split(' ').ToArray();
                string currCommand = commandLine[0];

                if (currCommand == "Shoot")
                {
                    int index = int.Parse(commandLine[1]);
                    int power = int.Parse(commandLine[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (currCommand == "Add")
                {
                    int index = int.Parse(commandLine[1]);
                    int value = int.Parse(commandLine[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid placement!");
                    }
                }
                else if (currCommand == "Strike")
                {
                    int index = int.Parse(commandLine[1]);
                    int radius = int.Parse(commandLine[2]);
                    if ((index >= 0 && index < targets.Count) &&
                        (index - radius >= 0 && index + radius < targets.Count))
                    {
                        targets.RemoveRange(index - radius, (index + radius + 1) - (index - radius));
                    }
                    else
                    {
                        Console.WriteLine($"Strike missed!");
                    }
                }
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}
