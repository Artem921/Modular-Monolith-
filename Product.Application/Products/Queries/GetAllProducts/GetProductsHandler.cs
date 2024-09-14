using Mapster;
using MediatR;
using Product.Application.DTO;
using Product.Domain.Abstraction;

namespace Product.Application.Products.Queries.GetAllProducts
{
    internal class GetProductsHandler : IRequestHandler<GetProductsRequest, IReadOnlyCollection<ProductDTO>>
    {
        private readonly IProductsRepository productsRepository;

        public GetProductsHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<IReadOnlyCollection<ProductDTO>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {

			var products = await productsRepository.GetAllAsync();

			return products is null ? throw new ArgumentNullException(nameof(products)) : products.Adapt<IReadOnlyCollection<ProductDTO>>();
        }
    }
}
