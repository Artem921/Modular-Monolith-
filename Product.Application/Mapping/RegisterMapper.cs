using Mapster;
using Product.Application.DTO;
using Product.Domain.Entities;

namespace Product.Application.Mapping
{
    internal class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<ProductDTO, ProductEntity>()
                .RequireDestinationMemberSource(true);
        }
    }
}
