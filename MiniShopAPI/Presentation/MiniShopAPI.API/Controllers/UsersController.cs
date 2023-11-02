using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniShopAPI.Application.Features.Commands.AppUser.CreateUser;

namespace MiniShopAPI.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);

            return Ok(response);
        }
    }
}

