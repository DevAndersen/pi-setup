using DevAndersen.Pi.Site.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace DevAndersen.Pi.Site.Web.Controllers;

public abstract class ViewController : Controller
{
    protected string? Title { get; set; }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
        ViewData[Constants.Views.TitleVariableName] = Title ?? GetTitle();
    }

    /// <summary>
    /// Returns the default title of the controller, to be used in the website header and title.
    /// By default, returns the controller's type name, without the "Controller" suffix, with individual words being separated by a space character.
    /// </summary>
    /// <returns></returns>
    protected virtual string GetTitle()
    {
        return Regex.Replace(NameWithoutControllerSuffix(GetType()), "(?!^)([A-Z])", " $0");
    }

    /// <summary>
    /// Returns the name of <typeparamref name="TController"/>, without the "Controller" suffix.
    /// If no such suffix is found, an empty string will be returned.
    /// </summary>
    /// <typeparam name="TController"></typeparam>
    /// <returns></returns>
    protected static string NameWithoutControllerSuffix<TController>() where TController : Controller
    {
        return NameWithoutControllerSuffix(typeof(TController));
    }

    /// <summary>
    /// Return the name of <paramref name="type"/>, without the "Controller" suffix.
    /// If no such suffix is found, an empty string will be returned.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    protected static string NameWithoutControllerSuffix(Type type)
    {
        Match match = Regex.Match(type.Name, "^(.+)Controller$");
        return match.Success
            ? match.Groups[1].Value
            : string.Empty;
    }
}
