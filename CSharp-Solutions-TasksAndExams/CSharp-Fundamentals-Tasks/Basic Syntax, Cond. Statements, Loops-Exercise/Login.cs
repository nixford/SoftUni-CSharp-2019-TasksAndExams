using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string reversedName = string.Empty;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                char symbol = userName[i];
                reversedName += symbol;
            }

            int count = 1;
            while (true)
            {
                string password = Console.ReadLine();
                if (password == reversedName)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else
                {
                    count++;
                    if (count > 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");                    
                    continue;
                }                   
            }
        }
    }
}
