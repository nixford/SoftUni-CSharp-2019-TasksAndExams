﻿using CarShop.Data;
using CarShop.Data.Models;
using SUS.MvcFramework;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(string username, string email, string password, string userType)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                IsMechanic = userType == "Mechanic" ? true : false,
                Password = ComputeHash(password),
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

        public string GetUserId(string username, string password)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == username);
            if (user?.Password != ComputeHash(password))
            {
                return null;
            }

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.db.Users.Any(x => x.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }

        public bool IsUserMechanic(string Userid)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == Userid);

            return user.IsMechanic;
        }

        public User GetUserByUserId(string userId)
        {
            return this.db.Users.FirstOrDefault(x => x.Id == userId);
        }
    }
}