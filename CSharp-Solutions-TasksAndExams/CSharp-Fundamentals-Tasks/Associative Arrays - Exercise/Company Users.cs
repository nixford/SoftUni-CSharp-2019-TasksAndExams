using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split('-', '>').Select(a => a.Trim()).ToArray();
            Dictionary<string, List<string>> dataBase = new Dictionary<string, List<string>>();

            while (inputLine[0] != "End")
            {
                string comanyName = inputLine[0];
                string employeeId = inputLine[2];                

                if (!dataBase.ContainsKey(comanyName))
                {
                    dataBase.Add(comanyName, new List<string>());
                    if (!dataBase[comanyName].Contains(employeeId))
                    {
                        dataBase[comanyName].Add(employeeId);
                    }                    
                }
                else if (dataBase.ContainsKey(comanyName))
                {
                    if (!dataBase[comanyName].Contains(employeeId))
                    {
                        dataBase[comanyName].Add(employeeId);
                    }
                }

                inputLine = Console.ReadLine().Split('-', '>').Select(a => a.Trim()).ToArray();
            }

            foreach (var item in dataBase.OrderBy(k => k.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var employeeId in item.Value)
                {
                    Console.WriteLine("-- " + employeeId);
                }
            }
        }
    }
}
