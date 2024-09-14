using Carts.Application.Carts.DTOs;
using MediatR;

namespace Carts.Application.Carts.Commands.AddItemToCart
{
    internal record AddItemToCartCommand(ItemCartDTO Item, string SessionId) : IRequest;
}
