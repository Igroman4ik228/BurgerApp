namespace BurgerApp.Database.Models
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public List<FoodIngridient> FoodIngridients { get; set; }
    }
}
