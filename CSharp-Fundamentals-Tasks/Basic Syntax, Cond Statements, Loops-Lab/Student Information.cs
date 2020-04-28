using System;

namespace OneBitCompany.ConsoleApplications.SoftUniDemo
{
    class Program 
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();

            string age = Console.ReadLine();
            int ageAsInteger = int.Parse(age);

            string avarageGrade = Console.ReadLine();
            double avarageGradeAsDouble = double.Parse(avarageGrade);

            Console.WriteLine($"Name: {studentName}, Age: {ageAsInteger}, Grade: {avarageGradeAsDouble:F2}");
        }
    }
}