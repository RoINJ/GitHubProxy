using Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace GitHubProxy.Controllers;

public class ProxyController : Controller
{
    private const string SiteUrl = "github.com";

    private readonly IMediator mediator;

    public ProxyController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task<IActionResult> Handle(string path)
    {
        var originalUrl = $"https://{SiteUrl}/{path}";

        var resultContent = await mediator.Send(new ModifyContentCommand { Url = originalUrl });
        var withReplacedLinks = Regex.Replace(resultContent, $"https://(www)*{SiteUrl}", $"https://{ControllerContext.HttpContext.Request.Host}");

        return Content(withReplacedLinks, "text/html");
    }
}
