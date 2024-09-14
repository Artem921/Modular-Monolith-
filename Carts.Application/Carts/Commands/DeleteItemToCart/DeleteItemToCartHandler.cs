using Carts.Domain.Abstraction;
using Carts.Domain.Entities;
using MediatR;

namespace Carts.Application.Carts.Commands.DeleteItemToCart
{
    internal class DeleteItemToCartHandler : IRequestHandler<DeleteItemToCartCommand>
    {
        private readonly ICacheService cacheService;

        public DeleteItemToCartHandler(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public async Task Handle(DeleteItemToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = cacheService.GetCachedData<Cart>(request.SessionId);

            if (cart != null)
            {
                var result = cart.RemovingItemFromCart(request.ItemId);

                if (result != 0)
                {
                    cacheService.SetCachedData(request.SessionId, cart, TimeSpan.FromDays(2));
                }

                else
                {
                    cacheService.ClearCachedData(request.SessionId);
                }
            }
        }
    }
}
