using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> itemBoxes = new List<Box>();
            string input = Console.ReadLine();
            double totalPrice = 0;

            while (input != "end")
            {
                string[] data = input.Split();

                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                double itemPrice = double.Parse(data[3]);
                totalPrice = itemQuantity * itemPrice;

                Box box = new Box();
                box.SerialNumber = serialNumber;
                box.ItemName = itemName;
                box.ItemQuantity = itemQuantity;
                box.PriceForBox = itemPrice;
                box.TotalPrice = totalPrice;

                itemBoxes.Add(box);

                input = Console.ReadLine();
            }
            List<Box> sortedBox = itemBoxes.OrderBy(boxes => boxes.TotalPrice).ToList();
            sortedBox.Reverse();

            foreach (Box box in sortedBox)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.ItemName} - ${box.PriceForBox:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.TotalPrice:F2}");
            }
        }
    }
    
    class Box
    {
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox { get; set; }
        public double TotalPrice { get; set; }
    }
}
