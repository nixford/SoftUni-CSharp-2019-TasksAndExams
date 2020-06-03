using System;

namespace Class_Box_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                box.GetSurfaceArea(box);
                box.GetLateralSurfaceArea(box);
                box.GetVolume(box);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }                      
        }
    }
}
