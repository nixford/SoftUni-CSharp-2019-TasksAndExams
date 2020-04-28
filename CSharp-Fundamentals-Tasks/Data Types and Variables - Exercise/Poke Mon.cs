using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            byte exaustionFactorY = byte.Parse(Console.ReadLine());
            int countTargets = 0;           
          
            int inititalPower = pokePowerN;

            // distance - pokePower untill pokepawer < distance

            while (distanceM <= pokePowerN)
            {                
                pokePowerN = pokePowerN - distanceM;
                countTargets++;
                
                if (pokePowerN == (inititalPower * 0.50))
                {
                    if (exaustionFactorY > 0)
                    {
                        pokePowerN = pokePowerN / exaustionFactorY;
                    }                   
                }               
            }
            Console.WriteLine(pokePowerN);
            Console.WriteLine(countTargets);
        }
    }
}
