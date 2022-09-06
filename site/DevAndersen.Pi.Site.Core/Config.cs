using Microsoft.Extensions.Configuration;

namespace DevAndersen.Pi.Site.Core;

public static class Config
{
    public static IConfiguration Configuration { get; set; } = default!;

    public static string FtpRoot => Configuration["SITE_FTP_ROOT"];

    public static string LocalIpAddress => Configuration["GENERAL_LOCAL_IP_ADDRESS"];
}
