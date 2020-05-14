using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowBollsNumber = int.Parse(Console.ReadLine());
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            long total = 0;
            long maxValue = long.MinValue;

            long currentSnowballSnow = 0;
            long currentSnowballTime = 0;
            long currentSnowballQuality = 0;
            long currentTotal = 0;
            long currentSnowballValue = 0;

            for (int i = 1; i <= snowBollsNumber; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());
                long snowballValue = snowballSnow / snowballTime;
                total = (long)Math.Pow(snowballValue, snowballQuality);

                if (total > maxValue)
                {
                    maxValue = total;
                    currentSnowballSnow = snowballSnow;
                    currentSnowballTime = snowballTime;
                    currentSnowballQuality = snowballQuality;
                    currentSnowballValue = snowballValue;
                    currentTotal = (long)Math.Pow(currentSnowballValue, currentSnowballQuality);
                }
            }
            Console.WriteLine($"{currentSnowballSnow} : {currentSnowballTime} = {maxValue} ({currentSnowballQuality})");
        }
    }
}
