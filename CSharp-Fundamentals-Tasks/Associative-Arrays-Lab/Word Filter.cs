using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ')
                .Where(w => w.Length % 2 == 0) 
                .ToArray();

            Console.WriteLine(string.Join("\n", words));
        }
    }
}
