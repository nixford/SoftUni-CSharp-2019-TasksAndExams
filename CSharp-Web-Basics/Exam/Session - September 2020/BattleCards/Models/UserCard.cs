using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Models
{
    public class UserCard
    {
        public UserCard()
        {
            this.Id = Guid.NewGuid().ToString();    
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string CardId { get; set; }

        public virtual Card Card { get; set; }
    }
}
