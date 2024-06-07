using BurgerApp.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BurgerApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = PasswordBox.Password;

            var user = AuthorizationService.Instance.AuthorizeUser(login, password);

            if (user != null)
            {
                AuthorizationService.Instance.CurrentUser = user;

                if (user.Role.Name == "Admin")
                {
                    NavigationService.Navigate(new AdminPanel());
                }
                else if (user.Role.Name == "User")
                {
                    NavigationService.Navigate(new WorkPlacePage());
                }
            }
            else
            {
                MessageBox.Show("Ты не смог войти!\nТолько задумайтесь... ещё вчера сегодня было завтра");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
