using MediatR;
using Product.Domain.Abstraction;
using Product.Domain.Entities;

namespace Product.Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductsRepository productsRepository;

        public UpdateProductHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = ProductEntity.Create(
              id: request.Product.Id,
              categoy: request.Product.Category,
              description: request.Product.Description,
              manufacture: request.Product.Manufacture,
              name: request.Product.Name,
              price: request.Product.Price,
              generation: request.Product.Generation,
              imgPath: request.Product.ImgPath);

            var result = await productsRepository.UpdateAsync(product);

            return result is false ? throw new NullReferenceException($"Объект какой то причине не изменён {nameof(UpdateProductHandler)}") : true;
        }
    }
}
