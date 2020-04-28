using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupNumber = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine(); // Students Business Regular
            string day = Console.ReadLine(); // Friday	Saturday	Sunday
            decimal totalPrice = 0;

            if (day == "Friday")
            {
                if (groupType == "Students")
                {
                    if (groupNumber >= 30)
                    {
                        totalPrice = (groupNumber * 8.45M) * 0.85M;
                    }
                    else
                    {
                        totalPrice = groupNumber * 8.45M;
                    }
                }
                else if (groupType == "Business")
                {
                    if (groupNumber >= 100)
                    {
                        totalPrice = (groupNumber - 10) * 10.90M;
                    }
                    else
                    {
                        totalPrice = groupNumber * 10.90M;
                    }
                }
                else if (groupType == "Regular")
                {
                    if (groupNumber >= 10 && groupNumber <= 20)
                    {
                        totalPrice = (groupNumber * 15) * 0.95M;
                    }
                    else
                    {
                        totalPrice = groupNumber * 15;
                    }
                }
            }
            else if (day == "Saturday")
            {
                if (groupType == "Students")
                {
                    if (groupNumber >= 30)
                    {
                        totalPrice = (groupNumber * 9.80M) * 0.85M;
                    }
                    else
                    {
                        totalPrice = groupNumber * 9.80M;
                    }
                }
                else if (groupType == "Business")
                {
                    if (groupNumber >= 100)
                    {
                        totalPrice = (groupNumber - 10) * 15.60M;
                    }
                    else
                    {
                        totalPrice = groupNumber * 15.60M;
                    }
                }
                else if (groupType == "Regular")
                {
                    if (groupNumber >= 10 && groupNumber <= 20)
                    {
                        totalPrice = (groupNumber * 20) * 0.95M;
                    }
                    else
                    {
                        totalPrice = groupNumber * 20;
                    }
                }
            }
            else if (day == "Sunday")
            {
                if (groupType == "Students")
                {
                    if (groupNumber >= 30)
                    {
                        totalPrice = (groupNumber * 10.46M) * 0.85M;
                    }
                    else
                    {
                        totalPrice = groupNumber * 10.46M;
                    }
                }
                else if (groupType == "Business")
                {
                    if (groupNumber >= 100)
                    {
                        totalPrice = (groupNumber - 10) * 16;
                    }
                    else
                    {
                        totalPrice = groupNumber * 16;
                    }
                }
                else if (groupType == "Regular")
                {
                    if (groupNumber >= 10 && groupNumber <= 20)
                    {
                        totalPrice = (groupNumber * 22.50M) * 0.95M;
                    }
                    else
                    {
                        totalPrice = groupNumber * 22.50M;
                    }
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
