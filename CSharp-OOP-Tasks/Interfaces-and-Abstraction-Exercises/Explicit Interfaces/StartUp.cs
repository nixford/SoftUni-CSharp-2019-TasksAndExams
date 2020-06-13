using System;

namespace Explicit
{
    public class StartUp
    {
        static void Main(string[] args)
        {            
            GetPrintAndTypeCast();
        }

        private static void GetPrintAndTypeCast()
        {
            var name = Console.ReadLine().Split();

            while (name[0] != "End")
            {
                var human = new Citizen(name[0]);
                Console.WriteLine(((IPerson)human).GetName());
                Console.WriteLine(((IResident)human).GetName());

                name = Console.ReadLine().Split();
            }
        }

        private static void PrintNamesAsDifferentInterfaces()
        {
            var name = Console.ReadLine().Split();

            while (name[0] != "End")
            {
                IPerson person = new Citizen(name[0]);
                Console.WriteLine(person.GetName());

                IResident resident = new Citizen(name[0]);
                Console.WriteLine(resident.GetName());

                name = Console.ReadLine().Split();
            }
        }
    }
}
