using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYeild = int.Parse(Console.ReadLine());
            decimal extracted = 0;           
            int days = 0;

            if (startingYeild >= 100)
            {
                while (true)
                {
                    if (startingYeild < 100)
                    {
                        break;
                    }

                    days++;
                    if (days == 1)
                    {
                        extracted = startingYeild - 26;
                    }
                    else
                    {
                        extracted = (extracted + startingYeild) - 26;
                    }
                    startingYeild = startingYeild - 10;
                }
                Console.WriteLine(days);
                Console.WriteLine(extracted - 26);
            }
            else
            {
                Console.WriteLine(days);
                Console.WriteLine(extracted);
            }  
        }
    }
}
