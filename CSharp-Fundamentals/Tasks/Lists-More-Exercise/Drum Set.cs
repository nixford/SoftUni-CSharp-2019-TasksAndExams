using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();
            int reducingPower = 0;
            List<int> initialQuality = new List<int>();

            foreach (var item in drumSet)
            {
                initialQuality.Add(item);
            }

            while (command != "Hit it again, Gabsy!")
            {
                reducingPower = int.Parse(command);
                for (int i = 0; i < drumSet.Count; i++)
                {                    
                    drumSet[i] = drumSet[i] - reducingPower;                    
                    if (drumSet[i] <= 0)
                    {                                                
                        if (savings >= 0)
                        {                            
                            if (initialQuality[i] * 3 <= savings)
                            {
                                savings = savings - (initialQuality[i] * 3);
                                drumSet[i] = initialQuality[i];
                            }
                            else
                            {
                                drumSet.RemoveAt(i);
                                initialQuality.RemoveAt(i);
                                if (i == 0)
                                {
                                    i = -1;
                                }
                            }                            
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                }
                command = Console.ReadLine();                
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
