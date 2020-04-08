using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesOfGifts = Console.ReadLine().Split(' ').ToArray();
            string[] commandLine = Console.ReadLine().Split(' ').ToArray();

            while (commandLine[0] != "No Money" && commandLine[1] != "Money")
            {
                string command = commandLine[0];
                string gift = commandLine[1];                

                if (command == "OutOfStock")
                {
                    for (int i = 0; i < namesOfGifts.Length; i++)
                    {
                        if (namesOfGifts[i] == gift)
                        {
                            namesOfGifts[i] = "None";
                        }
                    }
                }

                if (command == "Required")
                {
                    int index = int.Parse(commandLine[2]);
                    if (index >=0 && index < namesOfGifts.Length)
                    {
                        namesOfGifts[index] = gift;
                    }
                   
                }

                if (command == "JustInCase")
                {
                    namesOfGifts[namesOfGifts.Length - 1] = gift;
                }
                commandLine = Console.ReadLine().Split(' ').ToArray();
            }
            foreach (var gift in namesOfGifts)
            {
                if (gift != "None")
                {
                    Console.Write(gift + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
