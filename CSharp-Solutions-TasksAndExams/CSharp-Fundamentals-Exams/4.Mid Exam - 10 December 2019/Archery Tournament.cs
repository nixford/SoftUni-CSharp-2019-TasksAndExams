using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targetsList = Console.ReadLine().Split('|').Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            string[] commandList = command.Split('@').ToArray();

            int totalScore = 0;

            while (true)
            {
                if (command == "Game over")
                {
                    break;
                }
                commandList = command.Split(' ', '@').ToArray();                    

                if (commandList[0] == "Shoot")
                {
                    if (commandList[1] == "Left")
                    {
                        int startIndex = int.Parse(commandList[2]);
                        int length = int.Parse(commandList[3]);

                        if (startIndex >= 0 && startIndex < targetsList.Length)
                        {
                            if (startIndex - length >= 0)
                            {
                                if (targetsList[startIndex - length] >= 5)
                                {
                                    targetsList[startIndex - length] = targetsList[startIndex - length] - 5;
                                    totalScore = totalScore + 5;
                                }
                                else
                                {
                                    totalScore = totalScore + targetsList[startIndex - length];
                                    targetsList[startIndex - length] = 0;
                                }
                            }
                            else
                            {
                                if (length < targetsList.Length)
                                {
                                    int diff = targetsList.Length - Math.Abs(startIndex - length);
                                    int targetIndex = diff;
                                    if (targetsList[targetIndex] >= 5)
                                    {
                                        targetsList[targetIndex] = targetsList[targetIndex] - 5;
                                        totalScore = totalScore + 5;
                                    }
                                    else
                                    {
                                        int diff2 = targetsList.Length - Math.Abs(startIndex - length);
                                        int targetIndex2 = diff2;
                                        totalScore = totalScore + targetsList[targetIndex2];
                                        targetsList[targetIndex2] = 0;
                                    }
                                }
                                else if (length >= targetsList.Length) 
                                {
                                    if (length % targetsList.Length == 0)
                                    {
                                        int targetIndex = startIndex;
                                        if (targetsList[targetIndex] >= 5)
                                        {
                                            targetsList[targetIndex] = targetsList[targetIndex] - 5;
                                            totalScore = totalScore + 5;
                                        }
                                        else
                                        {
                                            int targetIndex2 = startIndex;
                                            totalScore = totalScore + targetsList[targetIndex2];
                                            targetsList[targetIndex2] = 0;
                                        }
                                    }
                                    else // (length > targetsList.Length) && length % targetsList.Length != 0
                                    {
                                        int diff = length % targetsList.Length;
                                        int targetIndex = targetsList.Length - diff;
                                        if (targetsList[targetIndex] >= 5)
                                        {
                                            targetsList[targetIndex] = targetsList[targetIndex] - 5;
                                            totalScore = totalScore + 5;
                                        }
                                        else
                                        {
                                            int diff2 = length % targetsList.Length;
                                            int targetIndex2 = targetsList.Length - diff2;
                                            targetsList[targetIndex2] = 0;
                                        }
                                    }
                                }                                 
                            }
                        }
                    }                    
                }

                if (commandList[0] == "Shoot")
                {
                    if (commandList[1] == "Right")
                    {
                        int startIndex = int.Parse(commandList[2]);
                        int length = int.Parse(commandList[3]);

                        if (startIndex >= 0 && startIndex < targetsList.Length)
                        {
                            if (startIndex + length < targetsList.Length)
                            {
                                if (targetsList[startIndex + length] >= 5)
                                {
                                    targetsList[startIndex + length] = targetsList[startIndex + length] - 5;
                                    totalScore = totalScore + 5;
                                }
                                else
                                {
                                    totalScore = totalScore + targetsList[startIndex + length];
                                    targetsList[startIndex + length] = 0;
                                }
                            }
                            else
                            {
                                if (length < targetsList.Length)
                                {
                                    int diff = (startIndex + length) - targetsList.Length;
                                    int targetIndex = diff;
                                    if (targetsList[targetIndex] >= 5)
                                    {
                                        targetsList[targetIndex] = targetsList[targetIndex] - 5;
                                        totalScore = totalScore + 5;
                                    }
                                    else
                                    {
                                        int diff2 = (startIndex + length) - targetsList.Length;
                                        int targetIndex2 = diff2;
                                        totalScore = totalScore + targetsList[targetIndex2];
                                        targetsList[targetIndex2] = 0;
                                    }
                                }
                                else if (length >= targetsList.Length)
                                {
                                    if (length % targetsList.Length == 0)
                                    {
                                        int targetIndex = startIndex;
                                        if (targetsList[targetIndex] >= 5)
                                        {
                                            targetsList[targetIndex] = targetsList[targetIndex] - 5;
                                            totalScore = totalScore + 5;
                                        }
                                        else
                                        {
                                            int targetIndex2 = startIndex;
                                            totalScore = totalScore + targetsList[targetIndex2];
                                            targetsList[targetIndex2] = 0;
                                        }
                                    }
                                    else // (length > targetsList.Length) && length % targetsList.Length != 0
                                    {
                                        int diff = length % targetsList.Length;
                                        int targetIndex = diff;
                                        if (targetsList[targetIndex] >= 5)
                                        {
                                            targetsList[targetIndex] = targetsList[targetIndex] - 5;
                                            totalScore = totalScore + 5;
                                        }
                                        else
                                        {
                                            int diff2 = length % targetsList.Length;
                                            int targetIndex2 = diff2;
                                            targetsList[targetIndex2] = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }                    
                }

                if (commandList[0] == "Reverse")
                {                    
                    Array.Reverse(targetsList);
                }

                command = Console.ReadLine();
                if (command == "Game over")
                {
                    break;
                }
            }
            
            Console.WriteLine(string.Join(" - ", targetsList));
            Console.WriteLine($"Iskren finished the archery tournament with {totalScore} points!");
        }
    }
}
