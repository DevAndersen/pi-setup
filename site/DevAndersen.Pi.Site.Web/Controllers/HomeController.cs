using DevAndersen.Pi.Site.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevAndersen.Pi.Site.Web.Controllers;

public class HomeController : ViewController
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
