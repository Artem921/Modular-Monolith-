using Carts.Domain.Abstraction;
using Carts.Domain.Entities;
using MediatR;

namespace Carts.Application.Carts.Commands.AddItemToCart
{
    internal class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand>
    {
        private readonly ICacheService cacheService;

        public AddItemToCartHandler(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public async Task Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            if (request.SessionId != string.Empty)
            {
                var cart = await Task.Run(() => cacheService.GetCachedData<Cart>(request.SessionId));

                var createItem = ItemCart.Create(

                id: request.Item.Id,
                generation: request.Item.Generation,
                manufacture: request.Item.Manufacture,
                price: request.Item.Price,
                categoy: request.Item.Category,
                description: request.Item.Description,
                name: request.Item.Name,
                imgPath: request.Item.ImgPath
                );

                if (cart is not null)
                {
                    cart.AddItemToCart(createItem);

                    await Task.Run(() => cacheService.SetCachedData(cart.Id.ToString(), cart, TimeSpan.FromDays(2)));

                }

                else
                {
                    var createdCart = new Cart(request.SessionId);

                    createdCart.AddItemToCart(createItem);

                    await Task.Run(() => cacheService.SetCachedData(createdCart.Id.ToString(), createdCart, TimeSpan.FromDays(2)));

                }
            }

        }
    }
}
