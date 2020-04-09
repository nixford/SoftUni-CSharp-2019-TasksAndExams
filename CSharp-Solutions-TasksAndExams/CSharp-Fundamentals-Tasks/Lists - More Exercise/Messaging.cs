using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputNumbers = Console.ReadLine().Split(' ').ToList();
            string inputText = Console.ReadLine();

            List<char> numbersInElement = new List<char>();           
            string temp = String.Empty;
            int currSum = 0;
            List<int> sumList = new List<int>();
            List<char> charText = inputText.ToList();

            // Sum current numbers in one element of the list
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                numbersInElement = inputNumbers[i].ToList();
                for (int j = 0; j < numbersInElement.Count; j++)
                {
                    temp = temp + numbersInElement[j].ToString();
                    currSum = currSum + (int.Parse(temp));                    
                    temp = String.Empty;
                }
                sumList.Add(currSum);
                currSum = 0;
                
                if (sumList[i] <= charText.Count)
                {
                    Console.Write(charText[sumList[i]]);
                    charText.RemoveAt(sumList[i] - 1);
                }
                else
                {
                    Console.Write(charText[sumList[i] % charText.Count]);
                    charText.RemoveAt(sumList[i] % charText.Count);
                }
                
            }
            Console.WriteLine();
        }
    }
}
