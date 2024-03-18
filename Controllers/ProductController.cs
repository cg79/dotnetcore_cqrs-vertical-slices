using CQRSVerticalSlices.Commands;
using CQRSVerticalSlices.Data;
using CQRSVerticalSlices.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSVerticalSlices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Get product by id.
        /// </summary>
        // GET api/product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await _mediator.Send(new GetProduct.Query(id));
            return response == null ? NotFound() : Ok(response);
        }

        /// <summary>
        /// Add product.
        /// </summary>
        // POST api/product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductToAddDto product)
        {
            var response = await _mediator.Send(new AddProduct.Command(product));
            return response == 0 ? BadRequest() : Ok(response);
        }
    }
}
