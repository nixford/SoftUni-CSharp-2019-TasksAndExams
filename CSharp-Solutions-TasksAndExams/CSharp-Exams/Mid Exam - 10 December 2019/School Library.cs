using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split('&').ToList();
            string command = Console.ReadLine();
            List<string> commandList = command.Split().ToList();

            while (command != "Done")
            {
                commandList = command.Split('|').Select(a => a.Trim()).ToList();
                string currCommand = commandList[0];

                if (currCommand == "Add Book")
                {
                    string bookName = commandList[1];
                    if (!inputList.Contains(bookName))
                    {
                        inputList.Insert(0, bookName);
                    }
                }
                                
                if (currCommand == "Take Book")
                {
                    string bookName = commandList[1];
                    if (inputList.Contains(bookName))
                    {
                        inputList.Remove(bookName);
                    }
                }

                if (currCommand == "Swap Books")
                {
                    string bookName1 = commandList[1];
                    string bookName2 = commandList[2];
                    if (inputList.Contains(bookName1) && inputList.Contains(bookName2))
                    {
                        int indexBook1 = inputList.IndexOf(bookName1);
                        int indexBook2 = inputList.IndexOf(bookName2);

                        string temp = inputList[indexBook1];
                        inputList[indexBook1] = inputList[indexBook2];
                        inputList[indexBook2] = temp;
                    }
                }

                if (currCommand == "Insert Book")
                {
                    string bookName = commandList[1];
                    inputList.Add(bookName);
                }

                if (currCommand == "Check Book")
                {
                    int index = int.Parse(commandList[1]);
                    if (index >= 0 && index < inputList.Count)
                    {
                        Console.WriteLine(inputList[index]);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", inputList));
        }
    }
}
