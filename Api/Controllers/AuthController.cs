﻿using Application.Features.Auth.Register;
using MediatR;
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
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }



    }
}
