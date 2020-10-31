using Musaca.Models;
using Musaca.Models.Enums;
using Musaca.Services;
using MUSACA.ViewModels.BindingModels.Users;
using MUSACA.ViewModels.Users;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Musaca.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;

        public UsersController(IUserService userService, IOrderService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInputModel model)
        {
            User userFromDb = this.userService.GetUserByUsernameAndPassword(model.Username, this.HashPassword(model.Password));

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            User user = new User
            {
                Username = model.Username,
                Password = this.HashPassword(model.Password),
                Email = model.Email
            };

            this.userService.CreateUser(user);
            this.orderService.CreateOrder(new Order { CashierId = user.Id });

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var viewModel = this.userService.GetOrdersByUsername(this.User.Id)
                .Where(x => x.Status == OrderStatus.Completed)
                .Select(
                x => new ProfileOrderViewModel
                {
                    Cashier = x.Cashier.Username,
                    IssuedOn = x.IssuedOn,
                    Id = x.Id,
                    Total = x.Products.Sum(p => p.Product.Price)

                }).ToList();

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}

