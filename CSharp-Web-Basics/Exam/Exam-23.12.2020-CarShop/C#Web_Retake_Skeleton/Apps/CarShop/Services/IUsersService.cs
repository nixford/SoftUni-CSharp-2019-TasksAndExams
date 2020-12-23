using CarShop.Data.Models;

namespace CarShop.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password, string userType);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        public bool IsUserMechanic(string Userid);

        public User GetUserByUserId(string userId);
    }
}
