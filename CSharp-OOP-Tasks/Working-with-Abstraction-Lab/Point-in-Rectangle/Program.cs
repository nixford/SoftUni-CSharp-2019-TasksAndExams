using System;
using System.Linq;

namespace Point_in_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();    

            Point topLeftPoint = new Point(input[0], input[1]);
            Point bottomRightPoint = new Point(input[2], input[3]);
            Rectangle rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int n = int.Parse(Console.ReadLine());            

            for (int i = 0; i < n; i++)
            {
                int[] currCoordinates = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                Point currPoint = new Point(currCoordinates[0], currCoordinates[1]);

                var result = rectangle.Contains(currPoint);

                Console.WriteLine(result);
            }
        }
    }
}
