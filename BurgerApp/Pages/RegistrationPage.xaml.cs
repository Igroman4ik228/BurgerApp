using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BurgerApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly RegistrationService _registrationService;
        private readonly ApplicationContext _context;
        private readonly AuthorizationService _authorizationService;
        private readonly MenuService _menuService;

        public RegistrationPage(RegistrationService registrationService, AuthorizationService authorizationService, ApplicationContext context,
            MenuService menuService)
        {
            InitializeComponent();

            _registrationService = registrationService;
            _context = context;
            _authorizationService = authorizationService;
            _menuService = menuService;
        }

        private void RegisterBtnClick(object sender, RoutedEventArgs e)
        {
            if (_registrationService.RegistrerUser(LoginBox.Text, PasswordBox.Password))
            {
                NavigationService.Navigate(new WorkPlacePage(_authorizationService, _context));
            }
            else
            {
                MessageBox.Show("Ошибка регистрации");
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage(_authorizationService, _context, _menuService, _registrationService));
        }
    }
}
