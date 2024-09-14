using MediatR;
using Product.Application.DTO;

namespace Product.Application.Products.Commands.DeleteProduct
{
    internal record DeleteProductCommand(Guid Id) : IRequest<ProductDTO>;
}
