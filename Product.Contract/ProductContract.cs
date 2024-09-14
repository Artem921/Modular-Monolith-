using Mapster;
using MediatR;
using Product.Application.DTO;
using Product.Application.Products.Queries.GetProductById;

namespace Product.Contract
{
    internal class ProductContract : IProductContract
    {
        private readonly IMediator mediator;

        public ProductContract(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid id)
        {
            var product = await mediator.Send(new GetProductByIdRequest(id));

            return product is null ? throw new NullReferenceException($"Продукта с таким Id не существует {nameof(product)}") : product.Adapt<ProductDTO>();
        }
    }
}


