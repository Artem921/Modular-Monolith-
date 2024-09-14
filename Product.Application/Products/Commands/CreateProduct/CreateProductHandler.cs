using MediatR;
using Product.Domain.Abstraction;
using Product.Domain.Entities;

namespace Product.Application.Products.Commands.CreateProduct
{
    internal class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductsRepository productsRepository;

        public CreateProductHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.product is null)
            {
                throw new NullReferenceException($"Пустая сылка {nameof(request.product)}");
            }

            var product  = await productsRepository.GetByIdAsync( request.product.Id );

            if(product is null)
            {
                request.product.Id = Guid.NewGuid();
            }

            var createdProduct = ProductEntity.Create(
                id: request.product.Id,
                categoy: request.product.Category,
                description: request.product.Description,
                manufacture: request.product.Manufacture,
                name: request.product.Name,
                price: request.product.Price,
                generation: request.product.Generation,
                imgPath: request.product.ImgPath);

            await productsRepository.CreateAsync(createdProduct);
        }

    }
}
