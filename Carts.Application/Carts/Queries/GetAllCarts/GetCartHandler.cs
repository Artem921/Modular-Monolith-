using Carts.Application.Carts.DTOs;
using Carts.Domain.Abstraction;
using Carts.Domain.Entities;
using Mapster;
using MediatR;

namespace Carts.Application.Carts.Queries.GetAllCarts
{
    internal class GetCartHandler : IRequestHandler<GetCartRequest, CartDTO>
    {
        private readonly ICacheService cacheService;

        public GetCartHandler(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public async Task<CartDTO> Handle(GetCartRequest request, CancellationToken cancellationToken)
        {
            var cart = await Task.Run(() => cacheService.GetCachedData<Cart>(request.SessionId));

            return cart is null ? throw new ArgumentNullException(nameof(cart)) : cart.Adapt<CartDTO>();
        }
    }
}
