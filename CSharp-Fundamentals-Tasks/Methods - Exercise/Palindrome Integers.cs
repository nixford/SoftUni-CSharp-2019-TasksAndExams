using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            GetPalindrome(input);
        }

        static void GetPalindrome(string input)
        {            
            while (input != "END")
            {                
                string reversedInput = string.Empty;
                for (int i = input.Length - 1; i > -1; i--)
                {
                    reversedInput += input[i];
                }
                if (input == reversedInput)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            }            
        }
    }
}
