using MediatR;
using Product.Application.DTO;

namespace Product.Application.Products.Commands.UpdateProduct
{
    internal record UpdateProductCommand : IRequest<bool>
    {
        public ProductDTO Product { get; set; }

        public UpdateProductCommand(ProductDTO Product)
        {
            this.Product = Product;
        }
    }


}
