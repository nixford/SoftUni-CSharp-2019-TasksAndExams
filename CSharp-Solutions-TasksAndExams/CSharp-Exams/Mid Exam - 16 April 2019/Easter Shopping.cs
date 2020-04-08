using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shopList = Console.ReadLine().Split(' ').ToList();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> commandList = Console.ReadLine().Split(' ').ToList();
                string command = commandList[0];

                if (command == "Include")
                {
                    string shop = commandList[1];
                    shopList.Add(shop);
                }

                if (command == "Visit")
                {
                    string firstOrLast = commandList[1];
                    int numberOfShops = int.Parse(commandList[2]);
                    if (numberOfShops <= shopList.Count)
                    {
                        if (firstOrLast == "first")
                        {
                            shopList.RemoveRange(0, numberOfShops);
                        }

                        if (firstOrLast == "last")
                        {  
                            int initialIndex = shopList.Count - numberOfShops;
                            for (int j = shopList.Count - 1; j >= initialIndex; j--)
                            {
                                shopList.RemoveAt(j);
                            }                            
                        }
                    }         
                }

                if (command == "Prefer")
                {
                    int shopIndex1 = int.Parse(commandList[1]);
                    int shopIndex2 = int.Parse(commandList[2]);                    

                    if ((shopIndex1 >= 0 && shopIndex1 < shopList.Count) && (shopIndex2 >= 0 && shopIndex2 < shopList.Count))
                    {
                        string temp = shopList[shopIndex1];
                        shopList[shopIndex1] = shopList[shopIndex2];
                        shopList[shopIndex2] = temp;
                    }
                }

                if (command == "Place")
                {
                    string shop = commandList[1];
                    int shopIndex = int.Parse(commandList[2]);
                    if (shopIndex + 1 >= 0 && shopIndex + 1 < shopList.Count)
                    {
                        shopList.Insert(shopIndex + 1, shop);
                    }
                }
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shopList));
        }
    }
}
