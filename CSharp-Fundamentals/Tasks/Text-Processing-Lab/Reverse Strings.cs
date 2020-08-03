using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] reversedWord = new char[input.Length];

            while (input != "end")
            {
                reversedWord = input.Reverse().ToArray();
                Console.WriteLine($"{input} = {string.Join("",reversedWord)}");
                input = Console.ReadLine();
            }
        }
    }
}
