using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MealPlanner.Controllers
{
    public class CreateMealController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        private List<Ingredient> _ingredients;

        public CreateMealController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _ingredients = _context.ingredient.ToList();
            
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

            List<MealIngredient> mealIngredients = JsonConvert.DeserializeObject<List<MealIngredient>>(MealIngredients);

            _context.meal.Add(new Meal() { Name = MealName, MealIngredients = mealIngredients });
            _context.SaveChanges();

            return RedirectToAction("CreateMeal", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

