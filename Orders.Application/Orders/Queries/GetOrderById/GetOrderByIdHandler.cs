using Mapster;
using MediatR;
using Orders.Application.Orders.DTOs;
using Orders.Domain.Abstraction;
using Orders.Domain.Entities;

namespace Orders.Application.Orders.Queries.GetOrderById
{
    internal class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, OrderDTO>
    {
        private readonly IOrdersRepository ordersRepository;

        public GetOrderByIdHandler(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await ordersRepository.GetByIdAsync(request.Id);

            return order is null ? throw new NullReferenceException($"В базе нет этого заказа {nameof(GetOrderByIdHandler)}") : order.Adapt<OrderDTO>();
        }
    }
}
