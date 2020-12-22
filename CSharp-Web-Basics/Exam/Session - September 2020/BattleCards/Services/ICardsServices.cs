using BattleCards.Models;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsServices
    {
        public void AddCard(string userId, AddCardInputModel input);

        public void AddCardToCollection(string userId, string cardId);

        public void RemoveCardCollection(string userId, string cardId);

        public IEnumerable<CardsViewModel> GetAll();

        public IEnumerable<CardsViewModel> GetCollection(string userId);

        public User GetUserByUserId(string userId);

        public Card GetCardById(string cardId);
    }
}
