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

    public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        ViewBag.Ingredients = new List<Ingredient>();
    }

    
    public IActionResult Index()
    {
        return View();
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

    [HttpGet]
    public IActionResult list()
    {
        

        List<Ingredient> result = _context.ingredient.ToList();
        TempData["ingredients"] = result.ToList();

        return Redirect("index");
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
