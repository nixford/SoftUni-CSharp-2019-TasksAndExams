using System;
using System.Collections.Generic;
using System.Linq;

namespace Border
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<IBuyer> peopleList = new List<IBuyer>();
            int totalFood = 0;

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                if (inputArgs.Length > 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];
                    string birthdate = inputArgs[3];

                    IBuyer citizen = new Citizens(name, age, id, birthdate);
                    peopleList.Add(citizen);
                }
                else
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string group = inputArgs[2];

                    IBuyer rebel = new Rebel(name, age, group);
                    peopleList.Add(rebel);
                }
            }


            string input = string.Empty;             
            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;

                if (peopleList.Any(p => p.Name == name))
                {
                    IBuyer citizenOrRebel = peopleList.FirstOrDefault(p => p.Name == name);
                    citizenOrRebel.BuyFood();                    
                }                              
            }

            totalFood = peopleList.Sum(p => p.Food);


            Console.WriteLine(totalFood);
        }
    }
}
