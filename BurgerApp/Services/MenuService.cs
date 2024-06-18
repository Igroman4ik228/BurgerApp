using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Models;
using System.Linq;

namespace BurgerApp.Services
{
    internal class MenuService
    {
        private static MenuService instance;
        public static MenuService Instance
        {
            get => instance ??= new MenuService();
        }
        public List<Ingridient> GetAllIngredients() => ApplicationContext.Instance.Ingridients.ToList();
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
        public void AddNewFoodIngredient(int foodId, int ingredientId, int countOfUnit)
        {
            var ingredient = ApplicationContext.Instance.Ingridients.FirstOrDefault(x => x.Id == ingredientId);
            var food = ApplicationContext.Instance.Foods.FirstOrDefault(x => x.Id == foodId);
            ApplicationContext.Instance.FoodIngridients.Add(new FoodIngridient
            {
                CountOfUnit = countOfUnit,
                Ingridient = ingredient,
                Food = food
            });
            ApplicationContext.Instance.SaveChanges();
        }
        public void EditFoodIngredient(int foodIngredientId, int ingredientId, int countOfUnit)
        {
            var foodIngredient = ApplicationContext.Instance.FoodIngridients.FirstOrDefault(x => x.Id == foodIngredientId);
            var ingredient = ApplicationContext.Instance.Ingridients.FirstOrDefault(x => x.Id == ingredientId);

            foodIngredient.Ingridient = ingredient;
            foodIngredient.CountOfUnit = countOfUnit;

            ApplicationContext.Instance.SaveChanges();
        }
        public void DeleteFoodIngredient(FoodIngridient foodIngredient) 
        {
            var removeItems = ApplicationContext.Instance.FoodIngridients
                .Where(x => x.Id == foodIngredient.Id)
                .ToList();

            ApplicationContext.Instance.FoodIngridients.RemoveRange(removeItems);

            ApplicationContext.Instance.SaveChanges();
        }

        public List<FoodIngridient> GetFoodIngredientsByFoodId(int foodId)
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
