using Carts.Application.Carts.DTOs;
using Carts.Domain.Entities;
using Mapster;

namespace Carts.Application.Carts.Mapping
{
    internal class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<ItemCartDTO, ItemCart>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<CartDTO, Cart>()
                .RequireDestinationMemberSource(true);
        }
    }
}
