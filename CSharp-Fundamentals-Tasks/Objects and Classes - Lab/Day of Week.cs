using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_And_Classes___Lab___exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            DateTime date = DateTime.ParseExact(
                input,
                "d-M-yyyy",
                CultureInfo.InvariantCulture);            
            Console.WriteLine(date.DayOfWeek);
        }
    }
}
