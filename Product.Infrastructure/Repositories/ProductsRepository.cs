using MongoDB.Driver;
using Product.Domain.Abstraction;
using Product.Domain.Entities;

namespace Product.Infrastructure.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly FilterDefinitionBuilder<ProductEntity> filterBuilder = Builders<ProductEntity>.Filter;
        private readonly IMongoCollection<ProductEntity> collection;

        public ProductsRepository(IMongoDatabase database)
        {
            //database.DropCollection("Products");
            collection = database.GetCollection<ProductEntity>("Products");
        }

        public async Task CreateAsync(ProductEntity product)
        {
            await collection.InsertOneAsync(product);
        }

        public async Task<bool> UpdateAsync(ProductEntity product)
        {
            var result = await collection.ReplaceOneAsync(filterBuilder.Eq(p => p.Id, product.Id), product);

            return result.IsAcknowledged;
        }

        public async Task<ProductEntity> DeleteAsync(Guid id)
        {
            var result = await collection.FindOneAndDeleteAsync(filterBuilder.Eq(p => p.Id, id));

            return result;
        }

        public async Task<IReadOnlyCollection<ProductEntity>> GetAllAsync()
        {

            var products = await collection.Find(filterBuilder.Empty).ToListAsync();

            return products;
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id)
        {
            var product = await collection.Find(filterBuilder.Eq(p => p.Id, id)).FirstOrDefaultAsync();
     
            return product;
        }
    }
}

