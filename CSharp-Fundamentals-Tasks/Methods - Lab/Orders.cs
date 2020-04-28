using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            GetTotalPrice(product, quantity);
        }

        static void GetTotalPrice(string product, int quantity)
        {
            double totalPrice = 0;
            if (product == "coffee")
            {
                totalPrice = quantity * 1.50;
            }
            else if (product == "water")
            {
                totalPrice = quantity * 1.00;
            }
            else if (product == "coke")
            {
                totalPrice = quantity * 1.40;
            }
            else if (product == "snacks")
            {
                totalPrice = quantity * 2.00;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
