using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Models;
using BurgerApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace BurgerApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public List<MenuItemDTO> menuItems = [];

        private readonly AuthorizationService _authorizationService;
        private readonly ApplicationContext _context;
        private readonly MenuService _menuService;

        public AdminPanel(AuthorizationService authorizationService, ApplicationContext context, MenuService menuService)
        {
            InitializeComponent();

            _authorizationService = authorizationService;
            _context = context;
            _menuService = menuService;

            HelloMessage();
            RefreshData();
        }

        public void HelloMessage()
        {
            var currentTime = DateTime.Now;
            var nowFormat = string.Format("{0}:{1}:{2}", currentTime.Hour, currentTime.Minute, currentTime.Second);
            User user = _authorizationService.CurrentUser;
            HelloBox.Text = $"Здравствуйте, {user.Login}\nВаша роль: {user.Role.Name}\nВремя авторизации: {nowFormat}";
        }

        private void RefreshData()
        {
            MyLBox.ItemsSource = null;
            menuItems.Clear();

            var allFood = _context.Foods
               .Include(x => x.Category)
               .ToList();

            foreach (var food in allFood)
            {
                var currentMenuItem = new MenuItemDTO()
                {
                    Id = food.Id,
                    FoodName = food.Name,
                    CategoryName = food.Category.Name,
                    Description = food.Description,
                    Price = food.Price
                };

                var allFoodIngredients = _context.FoodIngridients
                    .Include(x => x.Food)
                    .Include(x => x.Ingridient)
                    .ThenInclude(x => x.Unit)
                    .Where(x => x.Food.Id == food.Id);

                foreach (var foodIngridient in allFoodIngredients)
                {
                    currentMenuItem.Indgridients.Add($"{foodIngridient.Ingridient.Name}" +
                        $"- {foodIngridient.CountOfUnit} " +
                        $"{foodIngridient.Ingridient.Unit.Abbreviation}");
                }

                menuItems.Add(currentMenuItem);

            }
            MyLBox.ItemsSource = menuItems;
        }

        private void DeleteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MyLBox.SelectedItem is not MenuItemDTO item)
            {
                MessageBox.Show("Не выбран элемент");
                return;
            }

            var result = MessageBox.Show($"Вы уверенны, что хотите удалить {item.FoodName}?", "Внимание", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                _menuService.DeleteItem(item);

                RefreshData();
            }

        }
        private void EditIngredients_Click(object sender, RoutedEventArgs e)
        {
            if (MyLBox.SelectedItem is MenuItemDTO item)
            {
                NavigationService.Navigate(new EditIngredientsPage(item.Id, _menuService));
            }
        }

        private void ChangeBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddItemPage(_menuService, _authorizationService, _context));
        }


    }
}
