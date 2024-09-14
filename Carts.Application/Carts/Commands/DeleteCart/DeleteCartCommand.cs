using MediatR;

namespace Carts.Application.Carts.Commands.DeleteCart
{
    internal record DeleteCartCommand(string Id) : IRequest;
}
