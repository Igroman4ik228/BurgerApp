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

        private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new LoginPage());
        }
    }
}