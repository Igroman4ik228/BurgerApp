using BurgerApp.Database;
using BurgerApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Services
{
    public class AuthorizationService
    {
        public User? CurrentUser { get; set; }

        private static AuthorizationService instance;

        public static AuthorizationService Instance
        {
            get => instance ?? (instance = new AuthorizationService());
        }

        public User? AuthorizeUser(string login, string password)
        {

            var user = ApplicationContext.Instance.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Login == login);

            if (user == null)
            {
                return null;
            }

            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }

    }
}
