using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "int")
            {
                int number = int.Parse(Console.ReadLine());
                GetInt(number);
            }

            if (input == "real")
            {
                double number = double.Parse(Console.ReadLine());
                GetReal(number);
            }

            if (input == "string")
            {
                string text = Console.ReadLine();
                GetString(text);
            }
        }

        static void GetInt(int number)
        {            
            int output = number * 2;
            Console.WriteLine(output);
        }

        static void GetReal(double number)
        {
            double output = number * 1.5;
            Console.WriteLine($"{output:f2}");
        }

        static void GetString(string text)
        {
            string output = "$" + text + "$";
            Console.WriteLine(output);
        }
    }
}
