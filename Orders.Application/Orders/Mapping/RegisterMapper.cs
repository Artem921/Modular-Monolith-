using Mapster;
using Orders.Application.Orders.DTOs;
using Orders.Domain.Entities;

namespace Orders.Application.Orders.Mapping
{
    internal class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Order, OrderDTO>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<ItemOrderDTO, ItemOrder>()
                .RequireDestinationMemberSource(true);
        }
    }
}
