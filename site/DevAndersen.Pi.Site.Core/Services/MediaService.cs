using DevAndersen.Pi.Site.Core.Models;
using DevAndersen.Pi.Site.Core.Services.Abstractions;

namespace DevAndersen.Pi.Site.Core.Services;

public class MediaService : IMediaService
{
    private static readonly string[] thumbnailExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".tiff" };
    private static readonly string[] mediaExtensions = new[] { ".m4v", ".mp4", ".avi", ".mov" };

    private string basePath = Config.FtpRoot;
    private string relativeThumbnailPath = "/ftp";
    private string relativeFtpPath = string.Empty;

    public IEnumerable<MediaModel> GetMedia()
    {
        return FindNestedMedia(basePath);
    }

    private IEnumerable<MediaModel> FindNestedMedia(string path)
    {
        IEnumerable<string> directories = Directory.GetDirectories(path).OrderBy(x => x);

        if (directories.Any())
        {
            foreach (string directory in directories)
            {
                foreach (MediaModel model in FindNestedMedia(directory))
                {
                    yield return model;
                }
            }
        }
        else
        {
            string[] files = Directory.GetFiles(path);

            bool mediaSuccess = TryGetMatchingFile(files, mediaExtensions, out string? media);
            bool thumbnailSuccess = TryGetMatchingFile(files, thumbnailExtensions, out string? thumbnail);

            if (mediaSuccess)
            {
                yield return CreateMediaModel(media!, thumbnail ?? string.Empty);
            }
        }
    }

    private MediaModel CreateMediaModel(string media, string thumbnail)
    {
        media = media.Replace(basePath, relativeFtpPath).Replace(@"\", "/");
        thumbnail = thumbnail.Replace(basePath, relativeThumbnailPath).Replace(@"\", "/");
        return new MediaModel("ftp://" + media, thumbnail);
    }

    private static bool TryGetMatchingFile(string[] fileNames, string[] extensions, out string? result)
    {
        result = fileNames.FirstOrDefault(fileName => extensions.Contains(Path.GetExtension(fileName)));
        return !string.IsNullOrEmpty(result);
    }
}
