using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GitHubProxy.Controllers;

public class ProxyController : Controller
{
    private readonly IMediator mediator;

    public ProxyController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task<IActionResult> Handle(string path)
    {
        return null;
    }
}
