using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine()) + 30; 

            if (minutes >= 59)
            {
                hours++;
            }

            if (minutes >= 60)
            {
                minutes = minutes - 60;
            }

            if (hours > 23)
            {
                hours = hours - 24;
            }

            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}
