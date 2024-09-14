using Orders.Domain.Entities;

namespace Orders.Domain.Abstraction
{
    internal interface IOrdersRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order, ICollection<ItemOrder> items);
        Task<int> DeleteAsync(int id);
    }
}
