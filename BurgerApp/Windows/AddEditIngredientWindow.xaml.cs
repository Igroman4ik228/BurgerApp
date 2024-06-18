using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BurgerApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditIngredientWindow.xaml
    /// </summary>
    public partial class AddEditIngredientWindow : Window
    {
        private FoodIngridient _foodIngredient;
        private int _foodId;

        public AddEditIngredientWindow(FoodIngridient foodIngredient, int foodId)
        {
            InitializeComponent();
            _foodIngredient = foodIngredient;
            _foodId = foodId;

            List<Ingridient> ingredients = MenuService.Instance.GetAllIngredients();
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
                MenuService.Instance.AddNewFoodIngredient(_foodId, ingredient.Id, countOfUnit);
            }
            else 
            {
                MenuService.Instance.EditFoodIngredient(_foodIngredient.Id, ingredient.Id, countOfUnit);
            }

            Close();
        }
    }
}
