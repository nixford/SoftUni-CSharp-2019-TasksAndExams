using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split(':').ToArray();
            Dictionary<string, List<string>> dataBase = new Dictionary<string, List<string>>();
            while (inputLine[0] != "end")
            {
                string cource = inputLine[0].Trim();
                string student = inputLine[1].Trim();

                if (!dataBase.ContainsKey(cource))
                {
                    dataBase.Add(cource, new List<string>());
                    dataBase[cource].Add(student);
                }
                else
                {
                    dataBase[cource].Add(student);
                }
                inputLine = Console.ReadLine().Split(':').ToArray();
            }            
            foreach (var item in dataBase.OrderByDescending(v => v.Value.Count))
            {     
                Console.WriteLine(item.Key + ": " + item.Value.Count);
                item.Value.Sort();
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.WriteLine("-- " + item.Value[i]);
                }
            }
        }
    }
}
