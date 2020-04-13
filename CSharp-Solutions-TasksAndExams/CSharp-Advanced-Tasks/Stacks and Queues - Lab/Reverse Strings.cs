using System;
using System.Dynamic;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>(input);

            foreach (var letter in stack)
            {
                Console.Write(letter);
            }
        }
    }
}