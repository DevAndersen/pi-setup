using DevAndersen.Pi.Site.Core.Services.Abstractions;
using DevAndersen.Pi.Site.Core.Services;

namespace DevAndersen.Pi.Site.Web;

internal static class DependencyInjection
{
    public static void Inject(IServiceCollection services)
    {
        services.AddTransient<IMediaService, MediaService>();
    }
}
