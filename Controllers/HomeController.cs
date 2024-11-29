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
    private List<Meal> _meals;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        
    }

    
    public IActionResult Index()
    {
        IndexViewModel model = new IndexViewModel();
        return View(model);
    }

    public IActionResult Meals()
    {
        return View();
    }

    public IActionResult CreateMeal()
    {
        CreateMealViewModel model = new CreateMealViewModel();

        return View(model);
    }
    public IActionResult CreateIngredient()
    {
        CreateMealViewModel model = new CreateMealViewModel();

        return View(model);
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
