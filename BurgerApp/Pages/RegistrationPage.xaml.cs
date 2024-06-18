using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Services;
using Microsoft.EntityFrameworkCore;
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
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegisterBtnClick(object sender, RoutedEventArgs e)
        {
            if (RegistrationService.RegistrerUser(LoginBox.Text, PasswordBox.Password))
            {
                NavigationService.Navigate(new WorkPlacePage());
            }
            else
            {
                MessageBox.Show("Ошибка регистрации");
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
