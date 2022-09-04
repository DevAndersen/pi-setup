namespace DevAndersen.Pi.Site.Web.Models;

public class HomeViewModel
{
    public HomeButtonModel[] Buttons { get; set; }

    public HomeViewModel(HomeButtonModel[] buttons)
    {
        Buttons = buttons;
    }
}

public record HomeButtonModel(string Controller, string Action, string Text, string IconClass, string BackgroundColor);
