using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Services;
using System.Windows;
using System.Windows.Controls;

namespace BurgerApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Page
    {
        private readonly MenuService _menuService;
        private readonly ApplicationContext _context;
        private readonly AuthorizationService _authorizationService;

        public AddItemPage(MenuService menuService, AuthorizationService authorizationService, ApplicationContext context)
        {
            InitializeComponent();

            _menuService = menuService;
            _authorizationService = authorizationService;
            _context = context;

            var categories = _menuService.GetAllCategories();
            CategoryCBox.ItemsSource = categories;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string name = NameTBox.Text;
            string description = DescriptionTBox.Text;
            if (double.TryParse(PriceTBox.Text, out double priceResult))
            {
                MessageBox.Show("Некоректная цена");
                return;
            }
            int categoryId = ((Category)CategoryCBox.SelectedItem).Id;
            _menuService.AddNewMenuItem(name, description, priceResult, categoryId);
            NavigationService.Navigate(new WorkPlacePage(_authorizationService, _context));
        }
    }
}
