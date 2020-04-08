using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cardList = Console.ReadLine().Split(':').ToList();
            string command = Console.ReadLine();
            List<string> commandList = command.Split(' ').ToList();
            List<string> cardListNew = new List<string>();

            while (command != "Ready")
            {
                commandList = command.Split(' ').ToList();
                string currComand = commandList[0];

                if (currComand == "Add")
                {
                    string cardName = commandList[1];
                    if (cardList.Contains(cardName))
                    {
                        cardListNew.Add(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }

                if (currComand == "Insert")
                {
                    int index = int.Parse(commandList[2]);
                    string cardName = commandList[1];
                    if (cardList.Contains(cardName) && (index >= 0 && index < cardList.Count))
                    {
                        cardListNew.Insert(index, cardName);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }

                if (currComand == "Remove")
                {
                    string cardName = commandList[1];
                    if (cardListNew.Contains(cardName))
                    {
                        cardListNew.Remove(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }

                if (currComand == "Swap")
                {
                    string cardName1 = commandList[1];
                    string cardName2 = commandList[2];

                    int indexCard1 = cardListNew.IndexOf(cardName1);
                    int indexCard2 = cardListNew.IndexOf(cardName2);

                    string temp = cardListNew[indexCard1];
                    cardListNew[indexCard1] = cardListNew[indexCard2];
                    cardListNew[indexCard2] = temp;
                }

                if (currComand == "Shuffle")
                {
                    cardListNew.Reverse();
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", cardListNew));
        }
    }
}
