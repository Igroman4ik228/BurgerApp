using BurgerApp.Database.Models;
using BurgerApp.Models;
using BurgerApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using ApplicationContext = BurgerApp.Database.ApplicationContext;

namespace BurgerApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkPlacePage.xaml
    /// </summary>
    public partial class WorkPlacePage : Page
    {
        public List<MenuItemDTO> menuItems = [];
        public WorkPlacePage()
        {
            InitializeComponent();

            HelloMessage();


            var allFood = ApplicationContext.Instance.Foods
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

                var allFoodIngredients = ApplicationContext.Instance.FoodIngridients
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

        public void HelloMessage()
        {
            var currentTime = DateTime.Now;
            var nowFormat = string.Format("{0}:{1}:{2}", currentTime.Hour, currentTime.Minute, currentTime.Second);
            User user = AuthorizationService.Instance.CurrentUser;
            HelloBox.Text = $"Здравствуйте, {user.Login}\nВаша роль: {user.Role.Name}\nВремя авторизации: {nowFormat}";
        }
    }
}
