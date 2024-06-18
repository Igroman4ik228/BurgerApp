using BurgerApp.Database.Models;
using BurgerApp.Services;
using System.Windows;

namespace BurgerApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditIngredientWindow.xaml
    /// </summary>
    public partial class AddEditIngredientWindow : Window
    {
        private FoodIngridient _foodIngredient;
        private int _foodId;
        private readonly MenuService _menuService;

        public AddEditIngredientWindow(FoodIngridient foodIngredient, int foodId, MenuService menuService)
        {
            InitializeComponent();
            _foodIngredient = foodIngredient;
            _foodId = foodId;
            _menuService = menuService;

            List<Ingridient> ingredients = _menuService.GetAllIngredients();
            IngredientCBox.ItemsSource = ingredients;

            if (_foodIngredient != null)
            {
                CountTBox.Text = foodIngredient.CountOfUnit.ToString();
                IngredientCBox.SelectedItem = ingredients.FirstOrDefault(x => x.Id == foodIngredient.Ingridient.Id);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Ingridient ingredient = IngredientCBox.SelectedItem as Ingridient;
            int countOfUnit = int.Parse(CountTBox.Text);

            if (_foodIngredient == null)
            {
                _menuService.AddNewFoodIngredient(_foodId, ingredient.Id, countOfUnit);
            }
            else
            {
                _menuService.EditFoodIngredient(_foodIngredient.Id, ingredient.Id, countOfUnit);
            }

            Close();
        }
    }
}
