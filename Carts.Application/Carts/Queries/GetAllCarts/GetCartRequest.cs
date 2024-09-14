using Carts.Application.Carts.DTOs;
using MediatR;

namespace Carts.Application.Carts.Queries.GetAllCarts
{
    internal record GetCartRequest(string SessionId) : IRequest<CartDTO>
    {
    }
}
