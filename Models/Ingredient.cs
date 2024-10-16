using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Models
{
    
  

    public class Ingredient 
    {
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        public ICollection<MealIngredient> MealIngredients { get; set; }
    }
    
}
