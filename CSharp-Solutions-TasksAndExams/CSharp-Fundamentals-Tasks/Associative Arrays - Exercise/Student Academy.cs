using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dataBase = new Dictionary<string, List<double>>();
            Dictionary<string, double> output = new Dictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!dataBase.ContainsKey(student))
                {
                    dataBase.Add(student, new List<double>());
                    dataBase[student].Add(grade);
                }
                else
                {
                    dataBase[student].Add(grade);
                }
            }
            
            foreach (var item in dataBase.OrderByDescending(v => v.Value.Average()))
            {
                if (item.Value.Average() >= 4.50)
                {
                    Console.WriteLine(item.Key + " -> " + $"{item.Value.Average():f2}");
                }
            }           
        }
    }
}
