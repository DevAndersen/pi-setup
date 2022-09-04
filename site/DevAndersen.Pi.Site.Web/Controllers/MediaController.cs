using DevAndersen.Pi.Site.Core.Models;
using DevAndersen.Pi.Site.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DevAndersen.Pi.Site.Web.Controllers;

public class MediaController : ViewController
{
    private readonly IMediaService mediaService;

    public MediaController(IMediaService mediaService)
    {
        this.mediaService = mediaService;
    }

    public IActionResult Index()
    {
        IEnumerable<MediaModel> media = mediaService.GetMedia();
        return View(media);
    }
}
