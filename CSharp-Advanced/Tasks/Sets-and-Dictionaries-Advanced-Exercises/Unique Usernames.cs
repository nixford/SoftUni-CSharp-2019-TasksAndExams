using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                names.Add(input);
            }
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
