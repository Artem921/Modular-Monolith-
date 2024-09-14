using MediatR;
using Orders.Domain.Abstraction;

namespace Orders.Application.Orders.Commands.DeleteOrder
{
    internal class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand,bool>
    {
        private readonly IOrdersRepository ordersRepository;

        public DeleteOrderHandler(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result =await ordersRepository.DeleteAsync(request.Id);

            return result == 0 ? throw new NullReferenceException($"Объект с таким id  не существует {nameof(DeleteOrderHandler)}") : true;
        }
    }
}
