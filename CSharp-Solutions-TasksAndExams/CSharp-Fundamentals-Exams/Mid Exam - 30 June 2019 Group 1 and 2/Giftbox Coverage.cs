using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            int sheetsNumber = int.Parse(Console.ReadLine());
            double areaPerSheet = double.Parse(Console.ReadLine());

            double giftBoxArea = sideSize * sideSize * 6;

            double decreasedSheets = sheetsNumber / 3;
            double fullSheets = sheetsNumber - decreasedSheets;

            double sheetsArea = (fullSheets * areaPerSheet) + (decreasedSheets * (areaPerSheet * 0.25));           

            double percentage = (sheetsArea / giftBoxArea) * 100;

            Console.WriteLine($"You can cover {percentage:f2}% of the box.");
        }       
    }
}
