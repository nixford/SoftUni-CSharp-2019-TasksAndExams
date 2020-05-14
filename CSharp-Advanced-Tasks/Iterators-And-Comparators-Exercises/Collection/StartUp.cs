using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> elements = command
                    .Split()
                    .Skip(1)
                    .ToList();
            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            while ((command = Console.ReadLine()) != "END")
            {   
                if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "PrintAll")
                {
                    foreach (var item in listyIterator)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }    
        }
    }
}
