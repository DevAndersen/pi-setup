using DevAndersen.Pi.Site.Core.Models;

namespace DevAndersen.Pi.Site.Core.Services.Abstractions;

public interface IMediaService
{
    public IEnumerable<MediaModel> GetMedia();
}
