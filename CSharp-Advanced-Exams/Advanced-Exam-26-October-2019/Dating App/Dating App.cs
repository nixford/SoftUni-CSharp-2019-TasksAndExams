using System;
using System.Collections.Generic;
using System.Linq;

namespace Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {  

            int[] inputMales = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Stack<int> males = new Stack<int>(inputMales);

            int[] inputFemale = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Queue<int> females = new Queue<int>(inputFemale);

            int matches = 0;
            int currFemaleValue = 0;
            int currMaleValue = 0;

            while (males.Any() && females.Any())
            {
                currFemaleValue = females.Peek();
                currMaleValue = males.Peek();                               

                if (currFemaleValue <= 0 || currMaleValue <= 0)
                {
                    if (currFemaleValue <= 0)
                    {
                        females.Dequeue();                        
                    }                    
                    if (currMaleValue <= 0)
                    {
                        males.Pop();
                        
                    }
                    continue;
                }                

                if (currFemaleValue != 0 && currFemaleValue % 25 == 0 ||
                    currMaleValue != 0 && currMaleValue % 25 == 0)
                {
                    if (currFemaleValue != 0 && currFemaleValue % 25 == 0)
                    {
                        females.Dequeue();
                        if (!females.Any())
                        {
                            break;
                        }
                        females.Dequeue();
                    }
                    if (currMaleValue != 0 && currMaleValue % 25 == 0)
                    {
                        males.Pop();
                        if (!males.Any())
                        {
                            break;
                        }
                        males.Pop();
                    }
                    continue;
                }

                if (currFemaleValue == currMaleValue)
                {
                    matches++;

                    females.Dequeue();
                    males.Pop();                            
                }
                else
                {
                    females.Dequeue();
                    
                    int currLastMaleValue = currMaleValue;
                    males.Pop();
                    currLastMaleValue -= 2;
                    if (currLastMaleValue <= 0)
                    {
                        continue;
                    }
                    males.Push(currLastMaleValue);
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (males.Count <= 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.Write($"Males left: ");
                while (males.Any())
                {
                    Console.Write(males.Pop());
                    if (males.Count >= 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }

            if (females.Count <= 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {                
                Console.Write($"Females left: ");
                while (females.Any())
                {
                    Console.Write(females.Dequeue());
                    if (females.Count >= 1)
                    {
                        Console.Write(", ");
                    }
                }                
            }
        }
    }
}
