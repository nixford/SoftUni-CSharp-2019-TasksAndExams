using System;
using System.Linq;
using System.Text;

namespace P03_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                string[] args = Console.ReadLine().Split().ToArray();
                
                if (args[0] == "Create")
                {
                    studentSystem.AddStudent(args);
                }
                else if (args[0] == "Show")
                {
                    studentSystem.PrintStudent(studentSystem.GetCommented(args));
                }
                else if (args[0] == "Exit")
                {
                    break;
                }
            }
        }
    }
}
