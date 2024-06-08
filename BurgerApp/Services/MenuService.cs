using BurgerApp.Database;
using BurgerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services
{
    internal class MenuService
    {
        private static MenuService instance;
        public static MenuService Instance
        {
            get => instance ?? (instance = new MenuService());
        }
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
