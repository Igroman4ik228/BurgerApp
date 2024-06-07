namespace BurgerApp.Models
{
    public class MenuItemDTO
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<string> Indgridients { get; set; } = [];
        public double Price { get; set; }
    }
}
