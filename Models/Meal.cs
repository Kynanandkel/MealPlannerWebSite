using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Models;

public class Meal
{
    public int ID { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Name { get; set; }

    //link ingredients here
    public ICollection<MealIngredient> MealIngredients { get; set; }

}
