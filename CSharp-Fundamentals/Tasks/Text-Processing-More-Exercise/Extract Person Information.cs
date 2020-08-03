using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int nameStartIndex = input.IndexOf('@');
                int nameEndIndex = input.IndexOf('|');
                int ageStartIndex = input.IndexOf('#');
                int ageEndtIndex = input.IndexOf('*');
                string name = input.Substring(nameStartIndex + 1, nameEndIndex - nameStartIndex - 1);
                string age = input.Substring(ageStartIndex + 1, ageEndtIndex - ageStartIndex - 1);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
