using Application.Features.Products.Command.CreateProduct;
using Application.Features.Products.Command.UpdateProduct;
using Application.Features.Products.Queries.GetAllProduct;
using Application.Features.Products.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest request)
        {

           await _mediator.Send(request);

            return StatusCode(StatusCodes.Status201Created);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {

            await _mediator.Send(request);

            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetProductQueryRequest request = new()
            {
                Id = id
            };
            var data= await _mediator.Send(request);
            return Ok(data);

        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            GetAllProductQueryRequest request = new();
        
            var data = await _mediator.Send(request);
            return Ok(data);

        }



    }
}
