using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {

        private readonly ICardsServices cardsService;

        public CardsController(ICardsServices cardsService)
        {
            this.cardsService = cardsService;
        }
        public HttpResponse All()
        {
            var viewModel = this.cardsService.GetAll();

            return this.View(viewModel);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");

            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");

            }

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 5 || model.Name.Length > 15)
            {
                return this.Error("Name should be between 5 and 15 characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Keyword))
            {
                return this.Error("Keyword is required.");
            }

            if (model.Attack < 0)
            {
                return this.Error("Attack should be non-negative integer.");
            }

            if (model.Health < 0)
            {
                return this.Error("Health should be non-negative integer.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 200)
            {
                return this.Error("Description is required and its length should be at most 200 characters.");
            }

            var userId = this.GetUserId();

            this.cardsService.AddCard(userId, model);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse Collection()
        {
            var userId = this.GetUserId();
            var viewModel = this.cardsService.GetCollection(userId);

            return this.View(viewModel);
        }

        public HttpResponse AddToCollection(string cardId)
        {
            var userId = this.GetUserId();

            this.cardsService.AddCardToCollection(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(string cardId)
        {
            var userId = this.GetUserId();

            this.cardsService.RemoveCardCollection(userId, cardId);

            return this.Redirect("/Cards/Collection");
        }
    }
}
