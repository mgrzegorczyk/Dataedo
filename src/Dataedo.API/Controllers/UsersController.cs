using Dataedo.Application.Commands;
using Dataedo.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dataedo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator, ILogger<UserController> logger) : ControllerBase
{
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteUserCommand(id));
        logger.LogInformation($"User with ID {id} deleted!");

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await mediator.Send(new GetUsersQuery());

        return Ok(users);
    }
}