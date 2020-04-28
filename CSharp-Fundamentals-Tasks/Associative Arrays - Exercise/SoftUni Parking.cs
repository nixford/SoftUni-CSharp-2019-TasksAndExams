using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandNumbers = int.Parse(Console.ReadLine());

            Dictionary<string, string> usersData = new Dictionary<string, string>();
            List<string> commandList = new List<string>();

            for (int i = 0; i < commandNumbers; i++)
            {
                string input = Console.ReadLine();
                commandList = input.Split(' ').ToList();
                string username = commandList[1];                

                if (commandList[0] == "register")
                {
                    string licencePlateNumber = commandList[2];
                    if (!usersData.ContainsKey(username))
                    {
                        usersData.Add(username, licencePlateNumber);
                        Console.WriteLine($"{username} registered {licencePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licencePlateNumber}");
                    }
                }
                else if (commandList[0] == "unregister")
                {
                    if (!usersData.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        usersData.Remove(username);
                    }
                }
            }
            foreach (var user in usersData)
            {
                Console.WriteLine(user.Key + " => " + user.Value);
            }
        }
    }
}
