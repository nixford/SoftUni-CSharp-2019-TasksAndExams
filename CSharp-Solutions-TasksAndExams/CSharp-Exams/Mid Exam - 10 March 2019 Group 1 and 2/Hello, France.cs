using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputCollection = Console.ReadLine().Split('|').ToArray();
            double budged = double.Parse(Console.ReadLine());
            string[] tempArr = new string[3];
            List<double> boughtPriceList = new List<double>();
            List<double> oldPrices = new List<double>();

            for (int i = 0; i < inputCollection.Length; i++)
            {
                tempArr = inputCollection[i].Split('-', '>');

                if (tempArr[0] == "Clothes")
                {
                    if (double.Parse(tempArr[2]) <= 50)
                    {
                        if (budged - double.Parse(tempArr[2]) >= 0)
                        {
                            boughtPriceList.Add(double.Parse(tempArr[2]) * 1.40);
                            oldPrices.Add(double.Parse(tempArr[2]));
                            budged = budged - double.Parse(tempArr[2]);
                        }                        
                    }
                }

                if (tempArr[0] == "Shoes")
                {
                    if (double.Parse(tempArr[2]) <= 35)
                    {
                        if (budged - double.Parse(tempArr[2]) >= 0)
                        {
                            boughtPriceList.Add(double.Parse(tempArr[2]) * 1.40);
                            oldPrices.Add(double.Parse(tempArr[2]));
                            budged = budged - double.Parse(tempArr[2]);
                        }
                    }
                }

                if (tempArr[0] == "Accessories")
                {
                    if (double.Parse(tempArr[2]) <= 20.50)
                    {
                        if (budged - double.Parse(tempArr[2]) >= 0)
                        {
                            boughtPriceList.Add(double.Parse(tempArr[2]) * 1.40);
                            oldPrices.Add(double.Parse(tempArr[2]));
                            budged = budged - double.Parse(tempArr[2]);
                        }
                    }
                }
                tempArr = new string[3];                
            }
            double totalCollected = boughtPriceList.Sum() + budged;
            double totalOldPrices = oldPrices.Sum();

            if (totalCollected >= 150)
            {
                foreach (var item in boughtPriceList)
                {
                    double output = item;
                    Console.Write($"{output:f2}" + " ");

                }
                Console.WriteLine();
                Console.WriteLine($"Profit: {boughtPriceList.Sum() - totalOldPrices:f2}");
                Console.WriteLine($"Hello, France!");
            }
            else
            {
                foreach (var item in boughtPriceList)
                {
                    double output = item;
                    Console.Write($"{output:f2}" + " ");

                }
                Console.WriteLine();
                Console.WriteLine($"Profit: {boughtPriceList.Sum() - totalOldPrices:f2}");
                Console.WriteLine($"Time to go.");
            }
        }
    }
}
