using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sumOfRemovedElements = 0;

            while (sequenceList.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    int removedNumber1 = sequenceList[0];
                    sumOfRemovedElements = sumOfRemovedElements + removedNumber1;
                    sequenceList[0] = sequenceList[sequenceList.Count - 1];
                    for (int i = 0; i < sequenceList.Count; i++)
                    {
                        if (sequenceList[i] <= removedNumber1)
                        {
                            sequenceList[i] = sequenceList[i] + removedNumber1;
                        }
                        else
                        {
                            sequenceList[i] = sequenceList[i] - removedNumber1;
                        }
                    }
                }
                else if (index >= sequenceList.Count)
                {
                    int removedNumer2 = sequenceList[sequenceList.Count - 1];
                    sumOfRemovedElements = sumOfRemovedElements + removedNumer2;
                    sequenceList[sequenceList.Count - 1] = sequenceList[0];
                    for (int i = 0; i < sequenceList.Count; i++)
                    {
                        if (sequenceList[i] <= removedNumer2) 
                        {
                            sequenceList[i] = sequenceList[i] + removedNumer2;
                        }
                        else
                        {
                            sequenceList[i] = sequenceList[i] - removedNumer2;
                        }
                    }
                }
                else
                {
                    int removedNumber3 = sequenceList[index];
                    sumOfRemovedElements = sumOfRemovedElements + removedNumber3;
                    sequenceList.RemoveAt(index);

                    for (int i = 0; i < sequenceList.Count; i++)
                    {
                        if (sequenceList[i] <= removedNumber3)
                        {
                            sequenceList[i] = sequenceList[i] + removedNumber3;
                        }
                        else
                        {
                            sequenceList[i] = sequenceList[i] - removedNumber3;
                        }
                    }
                }
            }
            Console.WriteLine(sumOfRemovedElements);
        }
    }
}
