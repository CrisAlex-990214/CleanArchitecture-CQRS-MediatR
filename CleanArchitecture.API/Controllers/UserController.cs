using CleanArchitecture.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetUsers() => Ok(mediator.Send(new GetUsersRequest()));

        [HttpPost]
        public IActionResult AddUser(string name) => Ok(mediator.Send(new CreateUserRequest { Name = name }));
    }
}