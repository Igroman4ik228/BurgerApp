namespace BurgerApp.Database.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public List<Ingridient> Ingridients { get; set; }
    }
}
