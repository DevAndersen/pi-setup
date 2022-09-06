using Microsoft.AspNetCore.Mvc;

namespace DevAndersen.Pi.Site.Web.Controllers;

public class DashboardController : ViewController
{
    public IActionResult Index()
    {
        return View();
    }
}
