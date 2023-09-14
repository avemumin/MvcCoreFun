using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        List<Person> persons = new List<Person>
        {
            new (){FirstName = "Staś", LastName="Szczepański"},
            new (){FirstName = "Malwinka", LastName ="Szczepańska" }
        };


        return View("Privacy", persons);
    }

    public IActionResult About()
    {
        var tagi = new List<Abouts>()
        {
            new Abouts
            {
                Title = "Jakis",
                Description = "stek bzdur",
                Tags = new[] { "firstarg", "secondarg", "thirdarg" }
            },
            new Abouts
            {
                Title = "Drugi",
                Description = "same madrosci",
                Tags = new[] { "1", "2", "3" }
            }
        };


        return View("About", tagi);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
