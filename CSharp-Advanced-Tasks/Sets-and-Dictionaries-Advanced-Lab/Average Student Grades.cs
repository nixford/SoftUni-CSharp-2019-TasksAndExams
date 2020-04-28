using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> grades = 
                new Dictionary<string, List<decimal>>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split();                    
                string name = inputInfo[0];
                decimal grade = decimal.Parse(inputInfo[1]);                

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<decimal>());                    
                }
                grades[name].Add(grade);
            }
            foreach (var kvp in grades)
            {
                Console.Write($"{kvp.Key} -> ");
                foreach (var grade in kvp.Value)
                {
                    Console.Write($"{grade:F2} ");
                }
                Console.WriteLine($"(avg: {kvp.Value.Average():F2})");
            }
        }
    }
}
