using BurgerApp.Database.Models;
using BurgerApp.Services;
using System.Windows.Controls;

namespace BurgerApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();

            var currentTime = DateTime.Now;
            var nowFormat = string.Format("{0}:{1}:{2}", currentTime.Hour, currentTime.Minute, currentTime.Second);
            User user = AuthorizationService.Instance.CurrentUser;
            HelloBox.Text = $"Здравствуйте, {user.Login}\nВаша роль: {user.Role.Name}\nВремя авторизации: {nowFormat}";
        }
    }
}
