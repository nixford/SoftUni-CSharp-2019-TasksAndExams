using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> dataBase;
        public StudentSystem()
        {
            this.dataBase = new Dictionary<string, Student>();
        }
        
        public void AddStudent(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            if (!dataBase.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                dataBase[name] = student;
            }
        }

        public StringBuilder GetCommented(string[] args)
        {
            var name = args[1];
            StringBuilder sb = new StringBuilder();
            if (dataBase.ContainsKey(name))
            {
                var student = dataBase[name];                
                sb.Append($"{student.Name} is {student.Age} years old.");

                if (student.Grade >= 5.00)
                {
                    sb.Append(" Excellent student.");
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    sb.Append(" Average student.");
                }
                else
                {
                    sb.Append(" Very nice person.");
                }                
            }
            return sb;
        }

        public void PrintStudent(StringBuilder sb)
        {
            Console.WriteLine(sb.ToString());
        }
        
    }
}
