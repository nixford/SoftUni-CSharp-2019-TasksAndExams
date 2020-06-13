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
            List<IAliveCreatures> objectsList = new List<IAliveCreatures>();
           

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(' ')
                    .ToArray();
                string typeOfObject = inputArgs[0];

                if (typeOfObject == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthdate = inputArgs[4];

                    IAliveCreatures citizen = new Citizens(typeOfObject, name, age, id, birthdate);
                    objectsList.Add(citizen);
                }
                else if (typeOfObject == "Robot")
                {
                    string model = inputArgs[1];
                    string id = inputArgs[2];                                      
                }
                else if (typeOfObject == "Pet")
                {
                    string name = inputArgs[1];
                    string birthdate = inputArgs[2];

                    IAliveCreatures pet = new Pet(typeOfObject, name, birthdate);
                    objectsList.Add(pet);
                }                
            }

            string specialYear = Console.ReadLine();

            foreach (IAliveCreatures currObject in objectsList)
            {
                if (currObject.Birthdate.EndsWith(specialYear))
                {
                    Console.WriteLine(currObject.Birthdate);
                }
            }
        }
    }
}
