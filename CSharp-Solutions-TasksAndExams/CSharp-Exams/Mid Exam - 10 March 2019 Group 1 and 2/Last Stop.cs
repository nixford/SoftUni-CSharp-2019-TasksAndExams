using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintingsList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();
            List<string> commandList = command.Split(' ').ToList();

            while (command != "END")
            {
                commandList = command.Split(' ').ToList();
                if (commandList[0] == "Change")
                {
                    if (paintingsList.Contains(int.Parse(commandList[1])))
                    {
                        int index = 0;
                        index = paintingsList.IndexOf(int.Parse(commandList[1]));
                        paintingsList[index] = int.Parse(commandList[2]);
                    }
                }

                if (commandList[0] == "Hide")
                {
                    if (paintingsList.Contains(int.Parse(commandList[1])))
                    {                        
                        paintingsList.Remove(int.Parse(commandList[1]));                        
                    }
                }

                if (commandList[0] == "Switch")
                {
                    if (paintingsList.Contains(int.Parse(commandList[1])) && 
                        paintingsList.Contains(int.Parse(commandList[2])))
                    {
                        int indexPic1 = paintingsList.IndexOf(int.Parse(commandList[1]));
                        int indexPic2 = paintingsList.IndexOf(int.Parse(commandList[2]));

                        int temp = paintingsList[indexPic1];
                        paintingsList[indexPic1] = paintingsList[indexPic2];
                        paintingsList[indexPic2] = temp;
                    }
                }

                if (commandList[0] == "Insert")
                {
                    if (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < paintingsList.Count)
                    {
                        paintingsList.Insert(int.Parse(commandList[1]) + 1, int.Parse(commandList[2]));
                    }                    
                }

                if (commandList[0] == "Reverse")
                {
                    paintingsList.Reverse();
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", paintingsList));
        }
    }
}
