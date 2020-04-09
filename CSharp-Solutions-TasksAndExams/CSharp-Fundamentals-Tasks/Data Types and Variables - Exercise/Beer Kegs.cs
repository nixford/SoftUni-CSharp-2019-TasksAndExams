using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOfKegs = byte.Parse(Console.ReadLine());
            double volumeKeg = 0;
            double maxKeg = double.MinValue;
            string model = string.Empty;
            string currentModel = string.Empty;

            for (int currentKeg = 0; currentKeg < numberOfKegs; currentKeg++)
            {
                model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                volumeKeg = Math.PI * radius * radius * height;

                if (volumeKeg > maxKeg)
                {
                    maxKeg = volumeKeg;
                    currentModel = model;
                }
            }
            Console.WriteLine(currentModel);
        }
    }
}
