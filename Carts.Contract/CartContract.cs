using Carts.Application.Carts.Commands.DeleteCart;
using Carts.Application.Carts.DTOs;
using Carts.Application.Carts.Queries.GetAllCarts;
using Mapster;
using MediatR;

namespace Carts.Contract
{
    internal class CartContract : ICartContract
    {
        private readonly IMediator mediator;

        public CartContract(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task DeleteCart(string id)
        {
            await mediator.Send(new DeleteCartCommand(id));
        }

        public async Task<CartDTO> GetCartByIdAsync(string id)
        {
            var cart = await mediator.Send(new GetCartRequest(id));

            return cart is null ? throw new NullReferenceException($"Корзины с таким Id не существует {nameof(cart)}") : cart.Adapt<CartDTO>();
        }
    }
}
