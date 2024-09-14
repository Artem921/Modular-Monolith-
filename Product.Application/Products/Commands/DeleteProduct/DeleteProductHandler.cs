using Mapster;
using MediatR;
using Product.Application.DTO;
using Product.Domain.Abstraction;

namespace Product.Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductDTO>
    {
        private readonly IProductsRepository productsRepository;

        public DeleteProductHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<ProductDTO> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await productsRepository.DeleteAsync(request.Id);

            var product = result.Adapt<ProductDTO>();

            return result is null ? throw new NullReferenceException($"Объект какой то причине не удалён {nameof(DeleteProductHandler)}") : product;
        }
    }
}
