using MediatR;

namespace Orders.Application.Orders.Commands.DeleteOrder
{
    internal record DeleteOrderCommand (int Id): IRequest<bool>; 
    
}
