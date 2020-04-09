using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            GetGrade(grade);
        }

        static void GetGrade(double grade)
        {
            string gradeText = string.Empty;
            if (grade >= 2.00 && grade <= 2.99)
            {
                gradeText = "Fail";
            }
            else if (grade >= 3.00 && grade <= 3.49)
            {
                gradeText = "Poor";
            }
            else if (grade >= 3.50 && grade <= 4.49)
            {
                gradeText = "Good";
            }
            else if (grade >= 4.50 && grade <= 5.49)
            {
                gradeText = "Very good";
            }
            else if (grade >= 5.50 && grade <= 6.00)
            {
                gradeText = "Excellent";
            }
            Console.WriteLine(gradeText);
        }
    }
}
