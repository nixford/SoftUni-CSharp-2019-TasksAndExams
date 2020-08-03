using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {           
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double trashHeadset = 0;
            double trashMouse = 0;
            double trashKeyboard = 0;
            double trashDisplay = 0;            

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    trashHeadset++;
                }

                if (i % 3 == 0)
                {
                    trashMouse++;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    trashKeyboard++;
                }                
            }
            trashDisplay = Math.Floor(trashKeyboard / 2);
            double totalExpenses = (headsetPrice * trashHeadset) + (mousePrice * trashMouse) + (keyboardPrice * trashKeyboard) + (displayPrice * trashDisplay);
            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
