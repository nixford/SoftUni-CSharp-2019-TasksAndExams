using System;
using System.Collections.Generic;
using System.Linq;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carCountPassed = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Queue<string> carsQuee = new Queue<string>();
            int carNumbers = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carCountPassed; i++)
                    {
                        if (carsQuee.Any())
                        {
                            Console.WriteLine($"{carsQuee.Dequeue()} passed!");
                            carNumbers++;
                        }
                    }
                }
                else
                {
                    carsQuee.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{carNumbers} cars passed the crossroads.");
        }
    }
}
