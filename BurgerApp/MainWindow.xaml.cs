using BurgerApp.Database;
using BurgerApp.Pages;
using BurgerApp.Services;
using System.Windows;

namespace BurgerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationContext _context;
        private readonly AuthorizationService _authorizeService;
        private readonly MenuService _menuService;
        private readonly RegistrationService _registrationService;

        public MainWindow()
        {
            InitializeComponent();

            // DI
            _context = new ApplicationContext();
            _authorizeService = new AuthorizationService(_context);
            _menuService = new MenuService(_context);
            _registrationService = new RegistrationService(_context, _authorizeService);

            MainFrame.Navigate(new LoginPage(_authorizeService, _context, _menuService, _registrationService));

            string allUsers = "Вывод пользователей\n ";

            foreach (var user in _context.Users)
            {
                if (user.Login == "igroman4ik" || user.Login == "Admin")
                {
                    allUsers += $"{user.Id}\t {user.Login}\t Пароль такой же как логин\n";
                }
                else
                {
                    allUsers += $"{user.Id}\t {user.Login}\t {user.Password}\n";
                }
            }

            MessageBox.Show(allUsers);
        }

        private void Logo_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MainFrame.Content is LoginPage || MainFrame.Content is RegistrationPage)
            {
                return;
            }

            var answer = MessageBox.Show("Вы уверены что хотите выйти из аккаунта?", "Внимание", MessageBoxButton.YesNo);

            if (answer == MessageBoxResult.Yes)
            {
                MainFrame.Navigate(new LoginPage(_authorizeService, _context, _menuService, _registrationService));
            }

        }
    }
}