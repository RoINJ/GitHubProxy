using Core.PageDownload;
using MediatR;

namespace Core;

public class ModifyContentCommandHandler : IRequestHandler<ModifyContentCommand, string>
{
    private readonly IPageDownloader pageDownloader;

    public ModifyContentCommandHandler(IPageDownloader pageDownloader)
    {
        this.pageDownloader = pageDownloader;
    }

    public async Task<string> Handle(ModifyContentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var httpContent = await pageDownloader.GetPage(request.Url);
        var content = await httpContent.ReadAsStringAsync();

        return content;
    }
}
