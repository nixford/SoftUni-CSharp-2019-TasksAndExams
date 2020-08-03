using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace GenericBox
{
    class Startup
    {
        static void Main(string[] args)
        {           
            int n = int.Parse(Console.ReadLine());

            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                elements.Add(element);
                
            }
            Box<double> box = new Box<double>(elements);

            double elementToCompare = double.Parse(Console.ReadLine());

            int countOfGreaterElements = box.CountGreaterElements(elements, elementToCompare);

            Console.WriteLine(countOfGreaterElements);
        }
    }
}
