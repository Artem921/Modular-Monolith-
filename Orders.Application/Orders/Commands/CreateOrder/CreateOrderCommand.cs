using MediatR;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Commands.CreateOrder
{
    internal record CreateOrderCommand(OrderDTO Order) : IRequest;
    
  
}
