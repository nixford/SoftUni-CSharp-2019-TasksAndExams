using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsServices : ICardsServices
    {
        private readonly ApplicationDbContext db;

        public CardsServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCard(string userId, AddCardInputModel input)
        {
            var card = new Card()
            {
                Name = input.Name,
                ImageUrl = input.Image,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description,
            };
            db.Cards.Add(card);
            db.SaveChanges();

            var userCard = new UserCard
            {
                UserId = userId,
                CardId = card.Id,
            };
            db.UserCards.Add(userCard);
            db.SaveChanges();
        }

        public void AddCardToCollection(string userId, string cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(uc => uc.UserId == userId && uc.CardId == cardId);

            if (userCard != null)
            {
                return;
            }
            
            userCard = new UserCard
            {
                UserId = userId,
                CardId = cardId,
            };

            db.UserCards.Add(userCard);
            db.SaveChanges();
        }

        public void RemoveCardCollection(string userId, string cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(uc => uc.CardId == cardId && uc.UserId == userId);

            db.UserCards.Remove(userCard);
            db.SaveChanges();
        }

        public IEnumerable<CardsViewModel> GetAll()
        {
            return this.db.Cards
               .Select(x => new CardsViewModel
               {
                   CardId = x.Id,
                   Name = x.Name,
                   ImageUrl = x.ImageUrl,
                   Keyword = x.Keyword,
                   Attack = x.Attack,
                   Health = x.Health,
                   Description = x.Description,
               }).ToList();
        }

        public IEnumerable<CardsViewModel> GetCollection(string userId)
        {
            return this.db.UserCards
               .Where(uc => uc.UserId == userId)
               .Select(uc => new CardsViewModel
               {
                   CardId = uc.CardId,
                   Name = uc.Card.Name,
                   ImageUrl = uc.Card.ImageUrl,
                   Keyword = uc.Card.Keyword,
                   Attack = uc.Card.Attack,
                   Health = uc.Card.Health,
                   Description = uc.Card.Description,
               }).ToList();
        }

        public User GetUserByUserId(string userId)
        {
            return this.db.Users.FirstOrDefault(x => x.Id == userId);
        }

        public Card GetCardById(string cardId)
        {
            return this.db.Cards.FirstOrDefault(x => x.Id == cardId);
        }
    }
}
