using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split()                
                .ToArray();
            //AppendSir(names);

            Action<string[]> appendAction = w => 
            Console.WriteLine(string.Join("\r\n", w.Select(w => w = "Sir " + w)));

            appendAction(names);
        }
        //public static void AppendSir(string[] names)
        //{ 
        //    Console.WriteLine(string.Join("\r\n", names.Select(w => w = "Sir " + w)));
        //}
    }
}
