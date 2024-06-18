using BurgerApp.Database;
using BurgerApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace BurgerApp.Services
{
    public class RegistrationService(ApplicationContext context, AuthorizationService authorizationService)
    {
        private readonly AuthorizationService _authorizationService;
        private readonly ApplicationContext _context = context;

        public bool RegistrerUser(string login, string password)
        {
            if (_context.Users.FirstOrDefault(x => x.Login == login) != null)
            {
                MessageBox.Show("Логин занят");
                return false;
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Login = login,
                Password = passwordHash,
                RoleId = 2, // role is user
            };

            _context.Users
                .Add(user);
            _context.SaveChanges();


            user = _context.Users
                .OrderByDescending(u => u.Id)
                .Include(u => u.Role)
                .FirstOrDefault();

            _authorizationService.CurrentUser = user;
            return true;
        }
    }
}
