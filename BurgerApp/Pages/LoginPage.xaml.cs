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

        private void Login()
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

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                Login();
            }
        }
    }
}
