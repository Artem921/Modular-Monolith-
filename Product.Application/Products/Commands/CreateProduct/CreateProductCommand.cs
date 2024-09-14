using MediatR;
using Product.Application.DTO;

namespace Product.Application.Products.Commands.CreateProduct
{
    internal record CreateProductCommand(ProductDTO product) : IRequest;
}
