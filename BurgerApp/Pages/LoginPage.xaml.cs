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
        private readonly AuthorizationService _authorizationService;
        private readonly Database.ApplicationContext _context;
        private readonly MenuService _menuService;
        private readonly RegistrationService _registrationService;

        public LoginPage(AuthorizationService authorizationService, Database.ApplicationContext context, MenuService menuService,
            RegistrationService registrationService)
        {
            InitializeComponent();

            _authorizationService = authorizationService;
            _context = context;
            _menuService = menuService;
            _registrationService = registrationService;
        }

        private void Login()
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            var user = _authorizationService.AuthorizeUser(login, password);

            if (user != null)
            {
                _authorizationService.CurrentUser = user;

                if (user.Role.Name == "Admin")
                {
                    NavigationService.Navigate(new AdminPanel(_authorizationService, _context, _menuService));
                }
                else if (user.Role.Name == "User")
                {
                    NavigationService.Navigate(new WorkPlacePage(_authorizationService, _context));
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Ты не смог войти!\nТолько задумайтесь... ещё вчера сегодня было завтра");
            }
        }

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage(_registrationService, _authorizationService, _context, _menuService));
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Login();
            }
        }
    }
}
