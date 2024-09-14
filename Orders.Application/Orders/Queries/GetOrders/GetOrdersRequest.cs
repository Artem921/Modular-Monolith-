using MediatR;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Queries.GetOrders
{
    internal record GetOrdersRequest():IRequest<IReadOnlyCollection<OrderDTO>>;
    
}
