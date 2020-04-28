using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandNumber = int.Parse(Console.ReadLine());

            Stack<string> textEditor = new Stack<string>();
            StringBuilder text = new StringBuilder();
            char element = ' ';            

            for (int i = 0; i < commandNumber; i++)
            {
                string[] currCommand = Console.ReadLine()
                    .Split(new string[] { " " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (currCommand[0] == "1")
                {
                    textEditor.Push(text.ToString());
                    string subString = currCommand[1];
                    text.Append(subString);                    
                }
                else if (currCommand[0] == "2")
                {
                    textEditor.Push(text.ToString());
                    int count = int.Parse(currCommand[1]);
                    int startIndex = text.Length - count;
                    text.Remove(startIndex, count);                    
                }
                else if (currCommand[0] == "3")
                {
                    int index = int.Parse(currCommand[1]);
                    string currText = text.ToString();
                    element = currText.ElementAt(index - 1);
                    Console.WriteLine(element);
                }
                else if (currCommand[0] == "4" && textEditor.Any())
                {
                    text = new StringBuilder(textEditor.Pop());
                }
            }
        }
    }
}
