using BurgerApp.Database;
using BurgerApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace BurgerApp.Services
{
    internal class RegistrationService
    {
        public static bool RegistrerUser(string login, string password)
        {
            if (ApplicationContext.Instance.Users.FirstOrDefault(x => x.Login == login) != null)
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

            ApplicationContext.Instance.Users
                .Add(user);
            ApplicationContext.Instance.SaveChanges();


            user = ApplicationContext.Instance.Users
                .OrderByDescending(u => u.Id)
                .Include(u => u.Role)
                .FirstOrDefault();

            AuthorizationService.Instance.CurrentUser = user;
            return true;
        }
    }
}
