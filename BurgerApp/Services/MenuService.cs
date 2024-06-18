using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Models;

namespace BurgerApp.Services
{
    internal class MenuService
    {
        private static MenuService instance;
        public static MenuService Instance
        {
            get => instance ??= new MenuService();
        }

        public void AddNewMenuItem(string name, string description, double price, int categoryId)
        {
            var category = ApplicationContext.Instance.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                var food = new Food
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    Category = category,
                };
            }
        }

        public List<FoodIngridient> GetFoodIngridientsByFoodId(int foodId)
        {
            return ApplicationContext.Instance.FoodIngridients
                .Where(x => x.Food.Id == foodId)
                .ToList();
        }

        public List<Category> GetAllCategories() => ApplicationContext.Instance.Categories.ToList();

        public void DeleteItem(MenuItemDTO menuItemDTO)
        {
            var removeItems = ApplicationContext.Instance.FoodIngridients.Where(x => x.Id == menuItemDTO.Id).ToList();

            ApplicationContext.Instance.FoodIngridients.RemoveRange(removeItems);

            ApplicationContext.Instance.SaveChanges();


            var removeFoods = ApplicationContext.Instance.Foods.FirstOrDefault(x => x.Id == menuItemDTO.Id);

            ApplicationContext.Instance.Foods.Remove(removeFoods);

            ApplicationContext.Instance.SaveChanges();
        }

    }
}
