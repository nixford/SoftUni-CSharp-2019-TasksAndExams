using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string command = string.Empty;
            int index = 0;
            int currTarget = 0;
            int shotTargets = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                index = int.Parse(command);
                if (index >= 0 && index < targets.Length)
                {
                    if (targets[index] != -1)
                    {
                        currTarget = targets[index];
                        targets[index] = -1;
                        shotTargets++;
                        for (int i = 0; i < targets.Length; i++)
                        {
                            if (targets[i] > currTarget && targets[i] != -1)
                            {
                                targets[i] = targets[i] - currTarget;
                            }
                            else if (targets[i] <= currTarget && targets[i] != -1)
                            {
                                targets[i] = targets[i] + currTarget;
                            }                            
                        }                        
                    }                    
                }
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", targets)}");
        }
    }
}
