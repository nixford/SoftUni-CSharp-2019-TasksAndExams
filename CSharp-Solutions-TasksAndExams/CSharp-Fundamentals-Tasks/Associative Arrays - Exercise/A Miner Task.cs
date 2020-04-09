using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resources = string.Empty;
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            while (true)
            {
                resources = Console.ReadLine();
                if (resources == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(resources))
                {
                    dictionary.Add(resources, quantity);
                }
                else
                {
                    dictionary[resources] = dictionary[resources] + quantity;
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }            
        }
    }
}
