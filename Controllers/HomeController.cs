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
<<<<<<< HEAD
=======
    private ApplicationDbContext _context;
>>>>>>> 9d96919263e07075b85f283aa87710a701bdcca8
    private List<Meal> _meals;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
<<<<<<< HEAD
=======
        _context = context;
        _meals = context.meal.ToList();
>>>>>>> 9d96919263e07075b85f283aa87710a701bdcca8
        
    }

    
    public IActionResult Index()
    {
<<<<<<< HEAD
        IndexViewModel model = new IndexViewModel();
        return View(model);
=======
        IndexViewModel indexModel = new IndexViewModel();
        indexModel.Meals = _context.meal.ToList();

        var test = _context.mealIngredient.ToList();



        return View(indexModel);
>>>>>>> 9d96919263e07075b85f283aa87710a701bdcca8
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
