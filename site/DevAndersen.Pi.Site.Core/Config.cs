using Microsoft.Extensions.Configuration;

namespace DevAndersen.Pi.Site.Core;

public static class Config
{
    public static IConfiguration Configuration { get; set; } = default!;

    public static string FtpPath => Configuration["GENERAL_FTP_DOCKER_PATH"];
}
