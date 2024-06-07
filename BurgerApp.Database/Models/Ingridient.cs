using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
