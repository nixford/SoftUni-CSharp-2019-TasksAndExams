using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<char> leftSide = new Queue<char>(input);
            Stack<char> rightSide = new Stack<char>(input);
            bool areBalanced = true;

            if (input.Length % 2 != 0)
            {                
                Console.WriteLine("NO");
                return;
            }

            if ((input[0] == '(' && input[1] == ')') ||
                 (input[0] == '[' && input[1] == ']') ||
                 (input[0] == '{' && input[1] == '}'))
            {
                for (int i = 0; i < input.Length; i+=2)
                {
                    if ((input[0] == '(' && input[1] == ')') ||
                        (input[0] == '[' && input[1] == ']') ||
                        (input[0] == '{' && input[1] == '}'))
                    {
                        continue;
                    }
                    else
                    {
                        areBalanced = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < input.Length / 2; i++)
                {
                    if ((leftSide.Peek() == '(' && rightSide.Peek() == ')') ||
                        (leftSide.Peek() == '[' && rightSide.Peek() == ']') ||
                        (leftSide.Peek() == '{' && rightSide.Peek() == '}'))
                    {
                        leftSide.Dequeue();
                        rightSide.Pop();
                    }
                    else
                    {
                        areBalanced = false;
                        break;
                    }
                }
            }            

            if (areBalanced == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
