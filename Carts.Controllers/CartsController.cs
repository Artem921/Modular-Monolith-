using Carts.Application.Carts.Commands.AddItemToCart;
using Carts.Application.Carts.Commands.DeleteItemToCart;
using Carts.Application.Carts.DTOs;
using Carts.Application.Carts.Queries.GetAllCarts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Carts.Controllers
{
    [Route("carts")]
    [ApiController]
    internal class CartsController : Controller
    {
        private readonly IMediator mediator;

        public CartsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("AddItemToCart")]
        [HttpPost]
        public async Task<IActionResult> AddItemToCartAsync(ItemCartDTO itemCart)
        {
            try
            {
                var sessionId = HttpContext.Session.GetString("sessionId");

                if (sessionId == null)
                {
                    sessionId = HttpContext.Session.Id;
                    HttpContext.Session.SetString("sessionId", sessionId);
                }
             

                await mediator.Send(new AddItemToCartCommand(itemCart, sessionId));

                return StatusCode(201);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("GetCart")]
        [HttpGet]
        public async Task<IActionResult> GetCartAsync()
        {
           try
            {
                var sessionId = HttpContext.Session.GetString("sessionId");

                var cart = await mediator.Send(new GetCartRequest(sessionId));

                return Ok(cart);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("DeleteItemToCart")]
        [HttpDelete]
        public async Task<IActionResult> DeleteItemAsync(Guid itemId)
        {
            try
            {
                var sessionId = HttpContext.Session.GetString("sessionId");

                await mediator.Send(new DeleteItemToCartCommand(itemId, sessionId));

                return Ok(StatusCode(200));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
