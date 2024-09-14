using MediatR;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Queries.GetOrderById
{
    internal record GetOrderByIdRequest(int Id) : IRequest<OrderDTO>;
   
}
