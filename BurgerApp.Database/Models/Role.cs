using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Database.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<User> Users { get; set; }
    }
}
