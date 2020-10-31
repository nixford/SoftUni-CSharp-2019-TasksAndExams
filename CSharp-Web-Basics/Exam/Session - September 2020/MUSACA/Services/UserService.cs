using MUSACA.Data;
using MUSACA.Models;
using MUSACA.Services;
using System.Collections.Generic;
using System.Linq;

namespace Musaca.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext appDb)
        {
            this.context = appDb;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public IQueryable<Order> GetOrdersByUsername(string id)
        {
            var order = this.context.Orders.Where(x => x.CashierId == id);

            return order;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users.SingleOrDefault(user => (user.Username == username || user.Email == username)
                                                              && user.Password == password);
        }
    }
}
