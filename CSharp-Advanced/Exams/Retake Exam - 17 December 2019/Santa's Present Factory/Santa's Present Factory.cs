using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputMaterials = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Stack<int> materialsBox = new Stack<int>(inputMaterials);

            int[] inputMagicLevelValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> magicLevelBox = new Queue<int>(inputMagicLevelValues);

            Dictionary<string, int> presentsDict = new Dictionary<string, int>();


            while (materialsBox.Any() && magicLevelBox.Any())
            {
                int currMaterial = materialsBox.Peek();
                int currMagic = magicLevelBox.Peek();

                if (currMaterial == 0 || currMagic == 0)
                {
                    if (currMagic == 0)
                    {
                        magicLevelBox.Dequeue();                       
                    }
                    if (currMaterial == 0)
                    {
                        materialsBox.Pop();
                    }                   
                    continue;
                }

                if (currMagic == 0)
                {
                    magicLevelBox.Dequeue();
                    continue;
                }

                if (currMaterial * currMagic < 0)
                {
                    int currResult = currMaterial + currMagic;
                    materialsBox.Pop();
                    magicLevelBox.Dequeue();

                    materialsBox.Push(currResult);
                }
                else
                {
                    if (currMaterial * currMagic == 150)
                    {
                        materialsBox.Pop();
                        magicLevelBox.Dequeue();
                        if (!presentsDict.ContainsKey("Doll"))
                        {
                            presentsDict.Add("Doll", 1);
                        }
                        else
                        {
                            presentsDict["Doll"]++;
                        }
                    }
                    else if (currMaterial * currMagic == 250)
                    {
                        materialsBox.Pop();
                        magicLevelBox.Dequeue();
                        if (!presentsDict.ContainsKey("Wooden train"))
                        {
                            presentsDict.Add("Wooden train", 1);
                        }
                        else
                        {
                            presentsDict["Wooden train"]++;
                        }
                    }
                    else if (currMaterial * currMagic == 300)
                    {
                        materialsBox.Pop();
                        magicLevelBox.Dequeue();
                        if (!presentsDict.ContainsKey("Teddy bear"))
                        {
                            presentsDict.Add("Teddy bear", 1);
                        }
                        else
                        {
                            presentsDict["Teddy bear"]++;
                        }
                    }
                    else if (currMaterial * currMagic == 400)
                    {
                        materialsBox.Pop();
                        magicLevelBox.Dequeue();
                        if (!presentsDict.ContainsKey("Bicycle"))
                        {
                            presentsDict.Add("Bicycle", 1);
                        }
                        else
                        {
                            presentsDict["Bicycle"]++;
                        }
                    }
                    else
                    {
                        magicLevelBox.Dequeue();
                        int increaseMaterials = materialsBox.Pop() + 15;
                        materialsBox.Push(increaseMaterials);
                    }
                }                
            }

            if ((presentsDict.ContainsKey("Doll") && presentsDict.ContainsKey("Wooden train"))
                || (presentsDict.ContainsKey("Teddy bear") && presentsDict.ContainsKey("Bicycle")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");

                if (materialsBox.Any())
                {
                    Console.Write($"Materials left: ");
                    while (materialsBox.Any())
                    {
                        Console.Write(materialsBox.Pop());
                        if (materialsBox.Any())
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }

                if (magicLevelBox.Any())
                {
                    Console.Write($"Magic left: ");
                    while (magicLevelBox.Any())
                    {
                        Console.Write(magicLevelBox.Dequeue());
                        if (magicLevelBox.Any())
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }
                             
                foreach (var (toy, amount) in presentsDict.OrderBy(k => k.Key))
                {
                    Console.WriteLine($"{toy}: {amount}");
                }
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");

                if (materialsBox.Any())
                {
                    Console.Write($"Materials left: ");
                    while (materialsBox.Any())
                    {
                        Console.Write(materialsBox.Pop());
                        if (materialsBox.Any())
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }

                if (magicLevelBox.Any())
                {
                    Console.Write($"Magic left: ");
                    while (magicLevelBox.Any())
                    {
                        Console.Write(magicLevelBox.Dequeue());
                        if (magicLevelBox.Any())
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }

                foreach (var (toy, amount) in presentsDict.OrderBy(k => k.Key))
                {
                    Console.WriteLine($"{toy}: {amount}");
                }
            }
        }
    }
}
