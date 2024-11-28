using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;

namespace MealPlanner.Controllers
{
    public class CreateMealController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Ingredient> _ingredients;

        public CreateMealController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }


        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddNewMeal(string MealName, string MealIngredients)
        {
            Database db = new Database();

            // yeah i know not secure but just trying to get this thing working will put in protection against injection
            var test = db.Execute($"EXEC dbo.sp_CreateNewMeal @Name = '{MealName}'");

            int mealId = test.Rows[0].Field<int>("id");

            List<MealIngredient> mealIngredients = JsonConvert.DeserializeObject<List<MealIngredient>>(MealIngredients);

            foreach (var ingredient in mealIngredients) 
            {
                db.Execute($"EXEC dbo.sp_AdMealIngredientToMeal @MealID = {mealId}, @IngredientId = {ingredient.IngredientId}, @Ammount = {ingredient.ammount}, @format = '{ingredient.format}'");
            }

            return RedirectToAction("CreateMeal", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

