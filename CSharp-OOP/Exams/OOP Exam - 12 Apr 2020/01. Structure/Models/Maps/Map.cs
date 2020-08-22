using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {    
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players
                .Where(p => p.GetType().Name == typeof(Terrorist).Name)
                .ToList();
            var counterTerrorists = players
                .Where(p => p.GetType().Name == typeof(CounterTerrorist).Name)
                .ToList();

            while (terrorists.Any(t => t.Health > 0) &&
                counterTerrorists.Any(c => c.Health > 0))
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive == true)
                    {
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            int bulletsFired = terrorist.Gun.Fire();
                            counterTerrorist.TakeDamage(bulletsFired);
                        }                       
                    }                    
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive == true)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            int bulletsFired = counterTerrorist.Gun.Fire();
                            terrorist.TakeDamage(bulletsFired);
                        }                      
                    }                    
                }
            }

            if (counterTerrorists.Any(c => c.Health > 0))
            {
                return "Counter Terrorist wins!";
                
            }
            else
            {
                return "Terrorist wins!";
            }
        }
    }
}
