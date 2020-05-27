using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
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

            StackOfStrings stack = new StackOfStrings();

            bool result = stack.IsEmpty();
            stack.AddRange(list);

            while (stack.Any())
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
