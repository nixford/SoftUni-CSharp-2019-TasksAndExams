using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.roster.Any(n => n.Name == name))
            {
                this.roster.RemoveAll(n => n.Name == name);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(n => n.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(n => n.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classInput)
        {
            Player[] playersArr = this.roster
                                    .FindAll(c => c.Class == classInput)
                                    .ToArray();
            this.roster.RemoveAll(c => c.Class == classInput);

            return playersArr;
        }

      

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Players in the guild: {this.Name}");

            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
