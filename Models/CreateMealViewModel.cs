namespace MealPlanner.Models
{
    public class CreateMealViewModel
    {
        string MealName { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Ingredient> MealIngredients { get; set; }
    }
}
