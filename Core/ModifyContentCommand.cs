using MediatR;

namespace Core;

public class ModifyContentCommand : IRequest<string>
{
    public string Url { get; set; }
}
