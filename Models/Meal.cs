using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Models;

public class Meal
{
    public int ID { get; set; }
    public string? Name { get; set; }
   
    public List<MealIngredient> MealIngredients { get; set; }

    public Meal() 
    {
        MealIngredients = new List<MealIngredient>();
    }

}
