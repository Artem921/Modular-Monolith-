using Product.Application.DTO;

namespace Product.Contract
{
    public interface IProductContract
    {
         Task<ProductDTO> GetProductByIdAsync(Guid id);

    }
}
