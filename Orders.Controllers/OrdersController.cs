using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Orders.Commands.CreateOrder;
using Orders.Application.Orders.Commands.DeleteOrder;
using Orders.Application.Orders.DTOs;
using Orders.Application.Orders.Queries.GetOrderById;
using Orders.Application.Orders.Queries.GetOrders;

namespace Orders.Controllers
{
    [Route("orders")]
    [ApiController]
    internal class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("CreateOrder")]
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(OrderDTO order)
        {
            try
            {
                await mediator.Send(new CreateOrderCommand(order));

                return StatusCode(201);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("GetOrders")]
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            try
            {
                var result = await mediator.Send(new GetOrdersRequest());

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeleteOrder/{id}")]
		public async Task<IActionResult> DeleteOrderAsync([FromRoute] int id)
        {
            try
            {
                var result = await mediator.Send(new DeleteOrderCommand(id));

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("GetOrderById")]
        [HttpGet]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            try
            {
                var result = await mediator.Send(new GetOrderByIdRequest(id));

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
