using Mapster;
using MediatR;
using Orders.Application.Orders.DTOs;
using Orders.Domain.Abstraction;
using Orders.Domain.Entities;

namespace Orders.Application.Orders.Queries.GetOrders
{
    internal class GetOrdersHandler : IRequestHandler<GetOrdersRequest, IReadOnlyCollection<OrderDTO>>
    {
        private readonly IOrdersRepository ordersRepository;

        public GetOrdersHandler(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<IReadOnlyCollection<OrderDTO>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = await ordersRepository.GetAllAsync();

            var ordersList = new List<Order>();

            Order order =new();

            for (int i = 0; i <= orders.Count - 1; i++)
            {

                if (!ordersList.Select(i => i.Id).Contains(orders[i].Id))
                {
                   
                    order = Order.Create(
                    id: orders[i].Id,
                    name: orders[i].Name,
                    email: orders[i].Email,
                    phone: orders[i].Phone,
                    orderDate: orders[i].OrderDate);
                    ordersList.Add(order);

				}
                if (ordersList.Select(i => i.Id).Contains(orders[i].Id))
                {
					
					foreach (var item in orders[i].ItemsOrder)
                    {
                        var itemOrder = ItemOrder.Create(
                            id: item.Id,
                            category: item.Category,
                            description: item.Description,
                            name: item.Name,
                            price: item.Price,
                            generation: item.Generation,
                            orderId: orders[i].Id);

                        order.AddItems(itemOrder);
                    }
                }
                order.Price();
                order.AmountItems();

              
            } 
            
            
          
            return ordersList.Adapt<IReadOnlyCollection<OrderDTO>>();

        }
    }
}

