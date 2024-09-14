using MediatR;
using Product.Application.DTO;

namespace Product.Application.Products.Queries.GetProductById
{
    internal record GetProductByIdRequest(Guid Id) : IRequest<ProductDTO>;
}
