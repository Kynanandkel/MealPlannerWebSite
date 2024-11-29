using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;

namespace MealPlanner.Controllers
{
    public class CreateIngredientController : Controller
    {
        private readonly ILogger<HomeController> _logger;
            private List<Ingredient> _ingredients;

            public CreateIngredientController(ILogger<HomeController> logger)
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

            public IActionResult AddNewMeal(string IngredientName)
            {
                Database db = new Database();

                // yeah i know not secure but just trying to get this thing working will put in protection against injection
                var test = db.Execute($"EXEC dbo.sp_createIngredient @name = '{IngredientName}'");

                return RedirectToAction("Index", "Home");
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

    }
