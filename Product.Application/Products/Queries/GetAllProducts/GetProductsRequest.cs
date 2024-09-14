using MediatR;
using Product.Application.DTO;

namespace Product.Application.Products.Queries.GetAllProducts
{
    internal record GetProductsRequest : IRequest<IReadOnlyCollection<ProductDTO>>;
}
