using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Product.Domain.Abstraction;
using Product.Infrastructure.Repositories;
using Utils.Module;

namespace Product.Infrastructure
{
    public class ProductInfastructureModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddSingleton(provider =>
            {
                var configur = provider.GetRequiredService<IConfiguration>();
                var mongoSection = configur.GetSection("ProductDbSettings");
                var connectionString = mongoSection.GetValue<string>("ConnectionStrings");
                var database = mongoSection.GetValue<string>("DatabaseName");

                var mongoClient = new MongoClient(connectionString);
                return mongoClient.GetDatabase(database);
            });
        }
    }
}
