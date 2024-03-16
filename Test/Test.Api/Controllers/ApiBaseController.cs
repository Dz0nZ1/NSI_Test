using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ApiBaseController : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}