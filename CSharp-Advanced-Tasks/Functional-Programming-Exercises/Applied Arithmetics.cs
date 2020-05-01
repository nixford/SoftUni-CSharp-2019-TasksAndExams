using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;
            
            Action<int[]> printAction = arr => Console.Write(string.Join(" ", arr));

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    printAction(numbers);
                    Console.WriteLine();
                }
                else
                {
                    Func<int[], int[]> processor = GetProcessor(input);

                    numbers = processor(numbers);
                }
            }  
        }

        static Func<int[], int[]> GetProcessor(string input)
        {
            Func<int[], int[]> processor = null;

            if (input == "add")
            {
                processor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]++;
                    }
                    return arr;
                });
            }
            else if (input == "multiply")
            {
                processor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i] * 2;
                    }
                    return arr;
                });
            }
            else if (input == "subtract")
            {
                processor = new Func<int[], int[]>((arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]--;
                    }
                    return arr;
                });
            }
            return processor;
        }
    }
}
