using Application.Features.Auth.Command.Login;
using Application.Features.Auth.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            
            _mediator = mediator;
        }




        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
          var data=  await _mediator.Send(request);
            return Ok(data);
        }



    }
}
