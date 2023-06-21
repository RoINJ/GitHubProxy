namespace Core.PageDownload;

public interface IPageDownloader
{
    Task<HttpContent> GetPage(string url);
}
