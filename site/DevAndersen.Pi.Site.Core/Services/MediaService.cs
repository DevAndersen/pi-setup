using DevAndersen.Pi.Site.Core.Models;
using DevAndersen.Pi.Site.Core.Services.Abstractions;

namespace DevAndersen.Pi.Site.Core.Services;

public class MediaService : IMediaService
{
    public IEnumerable<MediaModel> GetMedia()
    {
        for (int i = 1; i <= 32; i++)
        {
            yield return new MediaModel($"m_{i}", $"t_{i}");
        }
    }
}
