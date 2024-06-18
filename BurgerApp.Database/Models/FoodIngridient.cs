namespace BurgerApp.Database.Models
{
    public class FoodIngridient
    {
        public int Id { get; set; }
        public Food Food { get; set; }
        public Ingridient Ingridient { get; set; }
        public int CountOfUnit { get; set; }
    }
}
