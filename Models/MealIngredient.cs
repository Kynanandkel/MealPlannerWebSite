using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Models
{
    public class MealIngredient
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }


        [Column(TypeName = "Float")]
        public float ammount { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string format { get; set; }
    }
}
