using MediatR;
using Orders.Domain.Abstraction;
using Orders.Domain.Entities;

namespace Orders.Application.Orders.Commands.CreateOrder
{
    internal class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
    {

        private readonly IOrdersRepository ordersRepository;
        public CreateOrderHandler(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orders = await ordersRepository.GetAllAsync();
            var orderId=  orders.Select(order => order.Id).LastOrDefault();

            var order = Order.Create(
                id: orderId + 1,
                name: request.Order.Name,
                email: request.Order.Email,
                phone: request.Order.Phone,
                orderDate: DateTime.UtcNow
                );

            foreach (var itemCart in request.Order.ItemsOrder)
            {
                var itemOrder = ItemOrder.Create(
                    id: itemCart.Id,
                    category: itemCart.Category,
                    description: itemCart.Description,
                    name: itemCart.Name,
                    price: itemCart.Price,
                    generation: itemCart.Generation,
                    orderId: order.Id);

                order.AddItems(itemOrder);
            }
            order.Price();
            order.AmountItems();

            await ordersRepository.AddAsync(order, order.ItemsOrder);

        }
    }
}

