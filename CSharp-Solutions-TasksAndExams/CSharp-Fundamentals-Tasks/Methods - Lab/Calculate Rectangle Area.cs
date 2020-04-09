using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double recArea = GetRectangleArea(a, b);            
            Console.WriteLine(recArea);
            //  Console.WriteLine(GetRectangleArea(a, b));
        }

        static double GetRectangleArea(double a, double b)
        {
            double area = a * b;
            return area;
        }
    }
}
