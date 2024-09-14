using Carts.Application.Carts.DTOs;
using MediatR;

namespace Carts.Application.Carts.Queries.GetItemById
{
    internal record GetItemByIdRequest(Guid Id) : IRequest<ItemCartDTO>;
}
