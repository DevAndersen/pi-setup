using DevAndersen.Pi.Site.Core;
using DevAndersen.Pi.Site.Core.Models;
using DevAndersen.Pi.Site.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
        string protocol = GetProtocolForUserAgent(Request.Headers["User-Agent"]);
        IEnumerable<MediaModel> media = mediaService.GetMedia().Select(x => x with
        {
            Media = $"{protocol}{Config.LocalIpAddress}{x.Media}"
        });
        return View(media);
    }

    private static string GetProtocolForUserAgent(string userAgent)
    {
        return Regex.Match(userAgent, "iPhone|iPad|iPod|Android", RegexOptions.IgnoreCase).Success
            ? "vlc://ftp://"
            : "ftp://";
    }
}
