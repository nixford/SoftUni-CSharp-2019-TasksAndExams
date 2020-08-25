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

            while (terrorists.Any(t => t.IsAlive) &&
                counterTerrorists.Any(c => c.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    if (!terrorist.IsAlive)
                    {
                        continue;
                    }

                    foreach (var counterTerrorist in counterTerrorists)
                    {
                        if (!counterTerrorist.IsAlive)
                        {
                            continue;
                        }

                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (!counterTerrorist.IsAlive)
                    {
                        continue;
                    }

                    foreach (var terrorist in terrorists)
                    {
                        if (!terrorist.IsAlive)
                        {
                            continue;
                        }

                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            if (counterTerrorists.Any(c => c.IsAlive))
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
