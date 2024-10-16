using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Models
{
    public class MealIngredient
    {
        public Meal meal { get; set; }

        public int mealId { get; set; }

        public Ingredient ingredient { get; set; }
        public int ingredientId { get; set; }

        [Column(TypeName = "Float")]
        public float ammount { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string format { get; set; }
    }
}
