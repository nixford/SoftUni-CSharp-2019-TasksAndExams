using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split(' ').ToArray();
            int quantity = 0;
            string material = string.Empty;
            SortedDictionary<string, int> keyMaterials = new SortedDictionary<string, int>();
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("motes", 0);
            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            bool isReached = false;
            string materialFirst = string.Empty;

            while (true)
            {
                for (int i = 0; i < inputLine.Length; i+=2)
                {
                    quantity = int.Parse(inputLine[i]);
                    material = inputLine[i + 1].ToLower();                    

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        if (!keyMaterials.ContainsKey(material))
                        {
                            keyMaterials.Add(material, quantity);
                        }
                        else
                        {
                            keyMaterials[material] = keyMaterials[material] + quantity;
                        }

                        foreach (var item in keyMaterials)
                        {
                            if (item.Value >= 250)
                            {
                                isReached = true;
                                materialFirst = item.Key;
                                keyMaterials[material] = keyMaterials[material] - 250;
                                break;
                            }
                        }
                        if (isReached == true)
                        {                            
                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(material))
                        {
                            junkItems.Add(material, quantity);
                        }
                        else
                        {
                            junkItems[material] = junkItems[material] + quantity;
                        }
                    }
                }
                if (isReached == true)
                {
                    if (materialFirst == "shards")
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        break;
                    }
                    else if (materialFirst == "fragments")
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        break;
                    }
                    else if (materialFirst == "motes")
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        break;
                    }                    
                }
                inputLine = Console.ReadLine().Split(' ').ToArray();                
            }

            foreach (var item in keyMaterials.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            { 
                Console.WriteLine(item.Key + ": " + item.Value);
            }

            foreach (var item in junkItems)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }           
        }
    }
}
