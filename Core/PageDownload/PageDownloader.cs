namespace Core.PageDownload;

public sealed class PageDownloader : IPageDownloader, IDisposable
{
    private HttpClient httpClient;
    private HttpClient HttpClient => httpClient ?? new HttpClient();

    public void Dispose() => httpClient?.Dispose();

    public async Task<HttpContent> GetPage(string url)
    {
        var response = await HttpClient.GetAsync(url);
        return response.Content;
    }
}
