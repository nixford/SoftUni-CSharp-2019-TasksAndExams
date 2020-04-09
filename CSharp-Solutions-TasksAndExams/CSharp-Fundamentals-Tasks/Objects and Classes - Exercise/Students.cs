using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudent = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < countOfStudent; i++)
            {
                string input = Console.ReadLine();
                string[] data = input.Split();

                string firstName = data[0];
                string secondName = data[1];
                double grade = double.Parse(data[2]);

                Student student = new Student()
                {
                    FirstName = firstName,
                    SecondName = secondName,
                    Grade = grade,
                };
                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.SecondName}: {student.Grade:f2}");
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }
    }
}