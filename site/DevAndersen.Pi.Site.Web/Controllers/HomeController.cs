using DevAndersen.Pi.Site.Core;
using DevAndersen.Pi.Site.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevAndersen.Pi.Site.Web.Controllers;

public class HomeController : ViewController
{
    public IActionResult Index()
    {
        return View(new HomeViewModel(new HomeButtonModel[]
        {
            CreateHomeViewModel<MediaController>(nameof(MediaController.Index), "Media", "bi-play-btn-fill", "#364aa8"),
            CreateHomeViewModel<DashboardController>(nameof(DashboardController.Index), "Dashboard", "bi-grid-1x2-fill", "#773b90"),
            CreateHomeViewModel<HomeController>(PiHoleAdminRedirect, "Pi-hole", "bi-shield-fill-check", "#b04443")
        }));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }

    public IActionResult PiHoleAdminRedirect() => Redirect($"http://{Config.LocalIpAddress}:{Config.PiholeAdminPort}");

    private static HomeButtonModel CreateHomeViewModel<TController>(string action, string text, string iconClass, string backgroundColor) where TController : Controller
    {
        return new HomeButtonModel(NameWithoutControllerSuffix<TController>(), action, text, iconClass, backgroundColor);
    }

    private static HomeButtonModel CreateHomeViewModel<TController>(Func<IActionResult> action, string text, string iconClass, string backgroundColor) where TController : Controller
    {
        return CreateHomeViewModel<TController>(action.Method.Name, text, iconClass, backgroundColor);
    }
}
