using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MealPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;



namespace MealPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _context;
    private List<Meal> _meals;

    public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        _meals = context.meal.ToList();
        
    }

    
    public IActionResult Index()
    {
        IndexViewModel indexModel = new IndexViewModel();
        indexModel.Meals = _context.meal.ToList();

        var test = _context.mealIngredient.ToList();



        return View(indexModel);
    }

    public IActionResult Meals()
    {
        return View();
    }

    public IActionResult CreateMeal()
    {
        CreateMealViewModel mealViewModel = new CreateMealViewModel();
        mealViewModel.Ingredients = _context.ingredient.ToList();

        return View(mealViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
