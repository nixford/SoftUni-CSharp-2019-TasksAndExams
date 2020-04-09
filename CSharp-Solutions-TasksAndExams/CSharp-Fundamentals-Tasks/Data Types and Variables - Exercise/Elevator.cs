using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int fullCourses = (int)(Math.Ceiling((double)peopleNumber / (double)elevatorCapacity));        

            Console.WriteLine(fullCourses);
        }
    }
}
