using Microsoft.AspNetCore.Mvc;

namespace DevAndersen.Pi.Site.Web.Controllers;

public class MediaController : ViewController
{
    public IActionResult Index()
    {
        return View();
    }
}
