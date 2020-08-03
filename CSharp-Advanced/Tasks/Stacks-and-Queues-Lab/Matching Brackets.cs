﻿using System;
using System.Collections;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();            

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    string output = input.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(output);
                }
            }
        }
    }
}
