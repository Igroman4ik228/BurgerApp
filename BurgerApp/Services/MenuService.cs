using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Models;
using System.Linq;

namespace BurgerApp.Services
{
    public class MenuService(ApplicationContext context)
    {
        private readonly ApplicationContext _context = context;


        public List<Ingridient> GetAllIngredients() => _context.Ingridients.ToList();
        public void AddNewMenuItem(string name, string description, double price, int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);

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
            var ingredient = _context.Ingridients.FirstOrDefault(x => x.Id == ingredientId);
            var food = _context.Foods.FirstOrDefault(x => x.Id == foodId);
            _context.FoodIngridients.Add(new FoodIngridient
            {
                CountOfUnit = countOfUnit,
                Ingridient = ingredient,
                Food = food
            });
            _context.SaveChanges();
        }
        public void EditFoodIngredient(int foodIngredientId, int ingredientId, int countOfUnit)
        {
            var foodIngredient = _context.FoodIngridients.FirstOrDefault(x => x.Id == foodIngredientId);
            var ingredient = _context.Ingridients.FirstOrDefault(x => x.Id == ingredientId);

            foodIngredient.Ingridient = ingredient;
            foodIngredient.CountOfUnit = countOfUnit;

            _context.SaveChanges();
        }
        public void DeleteFoodIngredient(FoodIngridient foodIngredient) 
        {
            var removeItems = _context.FoodIngridients
                .Where(x => x.Id == foodIngredient.Id)
                .ToList();

            _context.FoodIngridients.RemoveRange(removeItems);

            _context.SaveChanges();
        }

        public List<FoodIngridient> GetFoodIngredientsByFoodId(int foodId)
        {
            return _context.FoodIngridients
                .Where(x => x.Food.Id == foodId)
                .ToList();
        }

        public List<Category> GetAllCategories() => _context.Categories.ToList();

        public void DeleteItem(MenuItemDTO menuItemDTO)
        {
            var removeItems = _context.FoodIngridients.Where(x => x.Id == menuItemDTO.Id).ToList();

            _context.FoodIngridients.RemoveRange(removeItems);

            _context.SaveChanges();


            var removeFoods = _context.Foods.FirstOrDefault(x => x.Id == menuItemDTO.Id);

            _context.Foods.Remove(removeFoods);

            _context.SaveChanges();
        }

    }
}
