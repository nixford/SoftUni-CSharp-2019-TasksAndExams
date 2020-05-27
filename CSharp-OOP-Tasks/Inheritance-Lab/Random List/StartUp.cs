using Random_List;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list.Add("Four");
            list.Add("Five");
            list.Add("Six");
            list.Add("Seven");
            list.Add("Eight");
            list.Add("Nine");
            list.Add("Ten");

            Console.WriteLine(list.RemoveRandom());
        }
    }
}
