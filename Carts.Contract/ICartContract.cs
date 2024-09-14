using Carts.Application.Carts.DTOs;

namespace Carts.Contract
{
    public interface ICartContract
    {
        Task<CartDTO> GetCartByIdAsync(string id);
        Task DeleteCart(string id);
    }
}
