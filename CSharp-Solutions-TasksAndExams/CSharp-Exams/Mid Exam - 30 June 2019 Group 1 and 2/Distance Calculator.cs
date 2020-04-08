using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsNumber = int.Parse(Console.ReadLine());
            double stepLengthSantimeters = double.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
                        
            double normalStepsNumber = stepsNumber - (stepsNumber / 5);
            double shortStepsNumber = stepsNumber / 5;

            double stepsInM = stepLengthSantimeters / 100;

            double allStepsLenght = (normalStepsNumber * stepsInM) + (shortStepsNumber * (stepsInM * 0.70));            

            double percentage = (allStepsLenght / distanceM) * 100;

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}
