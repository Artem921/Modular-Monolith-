using Carts.Application.Carts.DTOs;
using MediatR;
using Product.Contract;

namespace Carts.Application.Carts.Queries.GetItemById
{
    internal class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, ItemCartDTO>
    {
        private readonly IProductContract productContract;
        public GetItemByIdHandler(IProductContract productContract)
        {
            this.productContract = productContract;
        }

        public async Task<ItemCartDTO> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {

            var product = await productContract.GetProductByIdAsync(request.Id);

            var item = new ItemCartDTO
            {
                Id = product.Id,
                Generation = product.Generation,
                Manufacture = product.Manufacture,
                Price = product.Price,
                Category = product.Category,
                Description = product.Description,
                Name = product.Name,
                ImgPath = product.ImgPath.First(),
            };

            return item;
        }
    }
}
