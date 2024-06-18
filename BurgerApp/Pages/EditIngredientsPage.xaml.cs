using BurgerApp.Services;
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
            Ig.ItemsSource = MenuService.Instance.GetFoodIngridientsByFoodId(foodId);
        }


        private void DeleteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
