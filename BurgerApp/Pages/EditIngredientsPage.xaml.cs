using BurgerApp.Database;
using BurgerApp.Database.Models;
using BurgerApp.Services;
using BurgerApp.Windows;
using System.Windows.Controls;

namespace BurgerApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditIngredientsPage.xaml
    /// </summary>
    public partial class EditIngredientsPage : Page
    {
        private int _id;
        public EditIngredientsPage(int foodId)
        {
            InitializeComponent();
            _id = foodId;
            RefreshData();
        }

        private void DeleteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new AddEditIngredientWindow(null, _id).ShowDialog();
            RefreshData();
        }

        private void EditBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = IngridientsLBox.SelectedItem as FoodIngridient;
            if (item != null) 
            {
                new AddEditIngredientWindow(item, _id).ShowDialog();    
            }
            RefreshData();
        }

        private void RefreshData()
        {
            IngridientsLBox.ItemsSource = null;

            var foodIngredients = MenuService.Instance.GetFoodIngredientsByFoodId(_id);
            IngridientsLBox.ItemsSource = foodIngredients;
        }
    }
}
