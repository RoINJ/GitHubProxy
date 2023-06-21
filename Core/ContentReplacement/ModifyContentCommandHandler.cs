using MediatR;

namespace Core.ContentReplacement;

public class ModifyContentCommandHandler : IRequestHandler<ModifyContentCommand, string>
{
    public Task<string> Handle(ModifyContentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
