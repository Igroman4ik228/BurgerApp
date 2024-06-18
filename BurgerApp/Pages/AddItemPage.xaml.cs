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
        public AddItemPage()
        {
            InitializeComponent();
            var categories = MenuService.Instance.GetAllCategories();

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
            MenuService.Instance.AddNewMenuItem(name, description, priceResult, categoryId);
            NavigationService.Navigate(new WorkPlacePage());
        }
    }
}
