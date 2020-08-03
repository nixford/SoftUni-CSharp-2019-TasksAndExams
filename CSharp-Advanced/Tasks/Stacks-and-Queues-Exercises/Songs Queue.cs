using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsList = Console.ReadLine()
                .Split(new string[] { ", " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> queueSongs = new Queue<string>(songsList);

            while (true)
            {
                if (!queueSongs.Any())
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, 2).ToArray();

                if (commandLine[0] == "Play")
                {
                    queueSongs.Dequeue();
                }
                else if (commandLine[0] == "Add")
                {
                    string song = commandLine[1];
                    if (!queueSongs.Contains(song))
                    {
                        queueSongs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (commandLine[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueSongs));
                }
            }
        }
    }
}
