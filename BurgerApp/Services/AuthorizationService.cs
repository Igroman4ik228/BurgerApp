using BurgerApp.Database;
using BurgerApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Services
{
    public class AuthorizationService(ApplicationContext context)
    {
        private readonly ApplicationContext _context = context;

        public User? CurrentUser { get; set; }

        public User? AuthorizeUser(string login, string password)
        {

            var user = _context.Users
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
