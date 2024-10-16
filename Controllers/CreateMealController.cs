using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace MealPlanner.Controllers
{
    public class CreateMealController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        private List<Ingredient> _ingredients;
        private List<int> _mealIngredients;

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
        
        [HttpGet]
        public IActionResult list(string name)
        {
            

            return Redirect("index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchIngredientForm(string IngredientName)
        {
            
            TempData["IngredientName"] = IngredientName;
            return RedirectToAction("CreateMeal", "Home");
        }

        [HttpPost]
        public IActionResult AddIngredientToMeal(int IngredientId)
        {
            if (_mealIngredients is null) 
            {
                _mealIngredients = new List<int>();
            }
            _mealIngredients.Add(IngredientId);
            TempData["mealIngredients"] = _mealIngredients.ToArray();
            TempData.Keep();
            return RedirectToAction("CreateMeal", "Home");
        }

        [HttpPost]
        public IActionResult RemoveIngredientFromMeal(int IngredientId)
        {

            TempData["IngredientIDRemove"] = IngredientId;
            return RedirectToAction("CreateMeal", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

