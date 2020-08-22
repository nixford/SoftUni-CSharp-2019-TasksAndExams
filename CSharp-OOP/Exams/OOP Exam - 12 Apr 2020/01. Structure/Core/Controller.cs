using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;
        private IPlayer player;

        public Controller()
        {
            guns = new GunRepository();
            players = new PlayerRepository();
            map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type == nameof(Pistol))
            {
                IGun currGun = new Pistol(name, bulletsCount);
                guns.Add(currGun);
                return $"Successfully added gun {currGun.Name}.";
            }
            else if (type == nameof(Rifle))
            {
                IGun currGun = new Rifle(name, bulletsCount);
                guns.Add(currGun);
                return $"Successfully added gun {currGun.Name}.";
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            if (type == nameof(Terrorist))
            {
                if (guns.FindByName(gunName) == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }
                IPlayer currPlayer = new Terrorist(username, health, armor, guns.FindByName(gunName));
                players.Add(currPlayer);
                
                return $"Successfully added player {currPlayer.Username}.";
            }
            else if (type == nameof(CounterTerrorist))
            {
                if (guns.FindByName(gunName) == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }
                IPlayer currPlayer = new CounterTerrorist(username, health, armor, guns.FindByName(gunName));
                players.Add(currPlayer);

                return $"Successfully added player {currPlayer.Username}.";
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in players.Models
                                            .OrderBy(p => p.GetType().Name)
                                            .ThenByDescending(p => p.Health)
                                            .ThenBy(p => p.Username))
            {
                sb
                    .AppendLine($"{player.GetType().Name}: {player.Username}")
                    .AppendLine($"--Health: {player.Health}")
                    .AppendLine($"--Armor: {player.Armor}")
                    .AppendLine($"--Gun: {player.Gun.Name}");
            }

            return sb.ToString().Trim();
        }

        public string StartGame()
        {
            return map.Start(players.Models.ToList());
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
