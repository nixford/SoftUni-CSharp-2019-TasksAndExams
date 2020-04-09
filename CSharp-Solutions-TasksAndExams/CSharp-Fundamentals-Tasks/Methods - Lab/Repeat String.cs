using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            GetText(input, n);
            Console.WriteLine(GetText(input, n));
        }

        static string GetText(string input, int n)
        {
            string result = string.Join("", Enumerable.Repeat(input, n));
            return result;
        }
    }
}
