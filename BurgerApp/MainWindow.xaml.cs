using BurgerApp.Database;
using BurgerApp.Pages;
using System.Windows;

namespace BurgerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new LoginPage());

            string allUsers = "Вывод пользователей\n ";

            foreach (var user in ApplicationContext.Instance.Users)
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
                MainFrame.Navigate(new LoginPage());
            }
            
        }
    }
}