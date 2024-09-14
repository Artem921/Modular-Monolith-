using Mapster;
using MediatR;
using Product.Application.DTO;
using Product.Domain.Abstraction;

namespace Product.Application.Products.Queries.GetProductById
{
    internal class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, ProductDTO>
    {
        private readonly IProductsRepository productsRepository;

        public GetProductByIdHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<ProductDTO> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await productsRepository.GetByIdAsync(request.Id);
     
            return product is null ? throw new NullReferenceException($"Продукта с таким Id не существует {nameof(product)}") : product.Adapt<ProductDTO>();
        }
    }
}
