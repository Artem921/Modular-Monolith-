using MediatR;

namespace Carts.Application.Carts.Commands.DeleteItemToCart
{
    internal record DeleteItemToCartCommand(Guid ItemId, string SessionId) : IRequest;
}
