using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private bool isAlive = true;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
            this.IsAlive = isAlive;
        }

        public string Username 
        {
            get => this.username;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }

        public int Health 
        {
            get => this.health;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor 
        {
            get => this.armor;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }

        public IGun Gun 
        {
            get => this.gun;
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }

        public bool IsAlive 
        {
            get => this.isAlive;
            private set 
            {
                if (Health <= 0)
                {
                    this.isAlive = false;
                }
                this.isAlive = true;
            }
        }

        public void TakeDamage(int points)
        {
            if (this.Armor - points > 0) // in case armor takes the full damage
            {
                this.Armor -= points;
                points = 0;
            }
            else // in case the armor takes part of the damage - fiding the ramaining points
            {
                points -= this.Armor;
                this.Armor = 0;
            }

            if (points > 0)
            {
                if (this.Health - points > 0)
                {
                    this.Health -= points;
                }
                else
                {
                    this.Health = 0;
                    IsAlive = false;
                }                
            }
        }
    }
}
