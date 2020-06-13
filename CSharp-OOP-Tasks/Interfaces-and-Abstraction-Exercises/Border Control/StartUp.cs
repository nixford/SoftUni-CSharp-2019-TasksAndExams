using System;
using System.Collections.Generic;
using System.Linq;

namespace Border
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<IObject> citizensAndRobotsList = new List<IObject>();
           

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(' ')
                    .ToArray();

                if (inputArgs.Length > 2)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];

                    IObject citizen = new Citizens(name, age, id);
                    citizensAndRobotsList.Add(citizen);
                }
                else
                {
                    string model = inputArgs[0];
                    string id = inputArgs[1];

                    IObject robot = new Robots(model, id);
                    citizensAndRobotsList.Add(robot);
                }
            }

            string fakeNumbers = Console.ReadLine();

            foreach (IObject currObject in citizensAndRobotsList)
            {
                if (currObject.Id.EndsWith(fakeNumbers))
                {
                    Console.WriteLine(currObject.Id);
                }
            }
        }
    }
}
