using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Database.Models
{
    public class FoodIngridient
    {
        public int Id { get; set; }
        public Food Food { get; set; }
        public Ingridient Ingridient { get; set; }
        public int CountOfUnit { get; set;}
    }
}
