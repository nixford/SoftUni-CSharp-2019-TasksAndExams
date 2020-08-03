using System;
using System.Collections.Generic;
using System.Globalization;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, int> dataBase = new Dictionary<string, int>();

            for (int i = 0; i < number; i++)
            {
                string currNumber = Console.ReadLine();
                if (!dataBase.ContainsKey(currNumber))
                {
                    dataBase.Add(currNumber, 1);
                }
                else
                {
                    dataBase[currNumber]++;
                }
            }

            foreach (var kvp in dataBase)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}
