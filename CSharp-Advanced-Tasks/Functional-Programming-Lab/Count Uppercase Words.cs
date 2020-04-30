using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {         
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            string[] textArr = Console.ReadLine()
                .Split(new string[] { " " },
              StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, textArr));
        }
    }
}
