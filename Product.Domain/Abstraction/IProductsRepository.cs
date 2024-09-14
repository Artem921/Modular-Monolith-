using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Domain.Entities;
namespace Product.Domain.Abstraction
{
    internal interface IProductsRepository
    {
        Task<IReadOnlyCollection<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetByIdAsync(Guid id);
        Task CreateAsync(ProductEntity product);
        Task<ProductEntity> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(ProductEntity product);

    }
}
