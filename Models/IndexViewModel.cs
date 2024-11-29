<<<<<<< HEAD
﻿using System.Data;
using MealPlanner.Models;

namespace MealPlanner.Models
{
    public class IndexViewModel
    {
        public List<Meal> meals = new List<Meal>();
        public IndexViewModel() 
        {
            Database db = new Database();
            
            var dbmeals = db.Execute("EXEC sp_getMealsAndIngredients");

            int curId = -1;
            int oldId = -1;
            Meal meal = new Meal();
            foreach (var row in dbmeals.AsEnumerable())
            {
                curId = row.Field<int>("mealId");
                
                if (oldId == curId)
                {
                    meal.MealIngredients.Add(new MealIngredient()
                    {
                        IngredientId = row.Field<int>("ingredientid"),
                        IngredientName = row.Field<string>("ingredientName"),
                        ammount = (float)row.Field<double>("ammount"),
                        format = row.Field<string>("format")
                    });
                }
                else 
                {
                    if(meal.Name is not null) 
                    {
                        meals.Add(meal);
                    }
                    meal = new Meal() 
                    {
                        ID = curId,
                        Name = row.Field<string>("mealName")
                    };
                }

                oldId = curId;
            }
            meals.Add(meal);
        }
=======
﻿namespace MealPlanner.Models
{
    public class IndexViewModel
    { 

        public List<Meal> Meals { get; set; }

        public List<Ingredient> Ingredients { get; set; }
>>>>>>> 9d96919263e07075b85f283aa87710a701bdcca8
        
    }
}
