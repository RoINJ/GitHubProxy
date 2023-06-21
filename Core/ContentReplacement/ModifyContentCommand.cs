using MediatR;

namespace Core.ContentReplacement;

public class ModifyContentCommand : IRequest<string>
{
    public string Content { get; set; }
}
