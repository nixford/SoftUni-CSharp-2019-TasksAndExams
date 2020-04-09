﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string typeOfPerson = string.Empty;

            if (age >= 0 && age <= 2)
            {
                typeOfPerson = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                typeOfPerson = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                typeOfPerson = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                typeOfPerson = "adult";
            }
            else if (age >= 65)
            {
                typeOfPerson = "elder";
            }
            Console.WriteLine(typeOfPerson);
        }
    }
}
