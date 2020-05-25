using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Hospital
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<List<string>>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Output")
            {
                string[] args = command.Split();
                var departament = args[0];
                var firstName = args[1];
                var lastName = args[2];
                var pacient = args[3];
                var fullName = firstName + lastName;

                if (!doctors.ContainsKey(firstName + lastName))
                {
                    doctors[fullName] = new List<string>();
                }

                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int currRoom = 0; currRoom < 20; currRoom++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool thereIsPlace = departments[departament].SelectMany(x => x).Count() < 60;

                if (thereIsPlace)
                {
                    AddPatients(doctors, departments, departament, pacient, fullName);
                }
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                PrintOutput(doctors, departments, args);

                command = Console.ReadLine();
            }
        }

        private static void AddPatients(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string pacient, string fullName)
        {
            int room = 0;
            doctors[fullName].Add(pacient);
            for (int bed = 0; bed < departments[departament].Count; bed++)
            {
                if (departments[departament][bed].Count < 3)
                {
                    room = bed;
                    break;
                }
            }
            departments[departament][room].Add(pacient);
        }

        private static void PrintOutput(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(string
                    .Join("\n", departments[args[0]]
                    .Where(x => x.Count > 0)
                    .SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                Console.WriteLine(string
                    .Join("\n", departments[args[0]][room - 1]
                    .OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string
                    .Join("\n", doctors[args[0] + args[1]]
                    .OrderBy(x => x)));
            }
        }
    }
}
