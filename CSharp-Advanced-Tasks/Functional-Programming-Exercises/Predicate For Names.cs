using System;
using System.Linq;

namespace Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesLenth = int.Parse(Console.ReadLine());

            Func<string, bool> filterFunc = n => n.Length <= namesLenth;
            Action<string[]> printAction = (arr) => Console.WriteLine(string.Join(Environment.NewLine, arr));

            string[] names = Console.ReadLine()
                .Split()
                .Where(filterFunc)
                .ToArray();
            
            printAction(names);
        }
    }
}
