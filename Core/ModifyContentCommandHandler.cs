using Core.ContentReplacement;
using Core.PageDownload;
using MediatR;
using System.Text.RegularExpressions;

namespace Core;

public class ModifyContentCommandHandler : IRequestHandler<ModifyContentCommand, string>
{
    private readonly IContentModifier contentModifier;
    private readonly IPageDownloader pageDownloader;

    public ModifyContentCommandHandler(
        IContentModifier contentModifier,
        IPageDownloader pageDownloader)
    {
        this.contentModifier = contentModifier;
        this.pageDownloader = pageDownloader;
    }

    public async Task<string> Handle(ModifyContentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var httpContent = await pageDownloader.GetPage(request.Url);
        var content = await httpContent.ReadAsStringAsync(cancellationToken);

        var modifiedContent = contentModifier.ModifyContent(content);

        return modifiedContent;
    }
}
