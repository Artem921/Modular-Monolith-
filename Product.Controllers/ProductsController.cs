using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTO;
using Product.Application.Products.Commands.CreateProduct;
using Product.Application.Products.Commands.DeleteProduct;
using Product.Application.Products.Commands.UpdateProduct;
using Product.Application.Products.Queries.GetAllProducts;
using Product.Application.Products.Queries.GetProductById;

namespace Product.Controllers
{
	[Route("products")]
    [ApiController]
    internal class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }



        [Route("GetProductById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductByIdAsync(Guid id)
        {        
            try
            {
                var product = await mediator.Send(new GetProductByIdRequest(id));

                return Ok(product);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
			try
            {
                var products = await mediator.Send(new GetProductsRequest());
				return (Ok(products));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

  
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> CreateProductAsync(ProductDTO productDTO)
        {
            try
            {
                await mediator.Send(new CreateProductCommand(productDTO));

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateProduct/{product}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDTO product)
        {
            try
            {
                var result = await mediator.Send(new UpdateProductCommand(product));

                return result is false ? BadRequest("Продукт не изменён") : StatusCode(StatusCodes.Status200OK);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

 
        [Route("DeleteProduct/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            try
            {
                var result = await mediator.Send(new DeleteProductCommand(id));

                return result is null ? BadRequest("Продукт не удалён") : StatusCode(StatusCodes.Status200OK);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
