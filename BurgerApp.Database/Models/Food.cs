namespace BurgerApp.Database.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public List<FoodIngridient> FoodIngridients { get; set; }

    }
}
