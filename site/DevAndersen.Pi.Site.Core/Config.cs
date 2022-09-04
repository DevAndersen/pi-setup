using Microsoft.Extensions.Configuration;

namespace DevAndersen.Pi.Site.Core;

public static class Config
{
    public static IConfiguration Configuration { get; set; } = default!;

    public static string Test => Configuration["path"];
}
