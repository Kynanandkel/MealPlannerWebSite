using System.Data;

namespace MealPlanner.Models
{
    public class CreateMealViewModel
    {
        public CreateMealViewModel() 
        {
            Ingredients = new List<Ingredient>();
            Database db = new Database();

            var test = db.Execute("EXEC sp_GetAllIngredients");

            foreach (var row in test.AsEnumerable()) 
            {
                Ingredients.Add(new Ingredient
                {
                    ID = row.Field<int>("ID"),
                    Name = row.Field<string>("name")
                });
            }
        }

        public List<Ingredient> Ingredients { get; set; }

    }
}
