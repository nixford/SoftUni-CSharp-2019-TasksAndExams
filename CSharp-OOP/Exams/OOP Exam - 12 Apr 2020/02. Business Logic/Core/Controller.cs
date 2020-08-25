using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private IRepository<IGun> guns;
        private IRepository<IPlayer> players;
        private IMap map;        

        public Controller()
        {
            guns = new GunRepository();
            players = new PlayerRepository();
            map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun currGun;

            if (type == "Pistol")
            {
                currGun = new Pistol(name, bulletsCount); 
            }
            else if (type == "Rifle")
            {
                currGun = new Rifle(name, bulletsCount);                
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(currGun);
            return $"Successfully added gun {currGun.Name}.";
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer currPlayer;

            if (type == "Terrorist")
            {
                currPlayer = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                currPlayer = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            this.players.Add(currPlayer);
            return $"Successfully added player {currPlayer.Username}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var players = this.players.Models
                              .OrderBy(p => p.GetType().Name)
                              .ThenByDescending(p => p.Health)
                              .ThenBy(p => p.Username);

            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
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
