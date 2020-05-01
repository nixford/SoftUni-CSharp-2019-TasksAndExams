using System;
using System.Linq;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split()
                .ToArray();
            //Print(text);

            Action<string[]> print = t => Console.WriteLine(string.Join("\r\n", t));

            print(text);

            //static void Print(string[] text)
            //{
            //    Console.WriteLine(string.Join("\r\n", text));
            //}
        }
    }
}
