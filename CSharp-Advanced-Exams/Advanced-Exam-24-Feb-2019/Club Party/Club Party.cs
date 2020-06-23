using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_Party2
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallMaxCapacity = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> hallsAndPeople = new Dictionary<string, List<int>>();
            Stack<string> input = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Queue<string> halls = new Queue<string>();

            while (input.Any())
            {
                string currChar = input.Peek();

                if (!char.IsDigit(currChar[0]))
                {
                    hallsAndPeople[currChar] = new List<int>();
                    halls.Enqueue(currChar);
                    input.Pop();
                    continue;
                }
                if (hallsAndPeople.Count == 0)
                {
                    input.Pop();
                    continue;
                }

                foreach (var hall in hallsAndPeople)
                {
                    if (hall.Value.Sum() + int.Parse(currChar) <= hallMaxCapacity)
                    {
                        hallsAndPeople[hall.Key].Add(int.Parse(currChar));
                        input.Pop();
                        break;
                    }

                    if (hall.Value.Sum() + int.Parse(currChar) >= hallMaxCapacity && halls.Any())
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hall.Value)}");
                        hallsAndPeople.Remove(hall.Key);
                    }

                    break;

                }
            }
        }
    }
}
