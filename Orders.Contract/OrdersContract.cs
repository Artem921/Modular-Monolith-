using MediatR;
using Orders.Application.Orders.Queries.GetOrderById;

namespace Orders.Contract
{
    internal class OrdersContract : IOrdersContract
    {
        private readonly IMediator mediator;

        public OrdersContract(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<int> GetIdByOrderAsync(int id)
        {
            var order = await mediator.Send(new GetOrderByIdRequest(id));

            return order.Id;
        }
    }
}
