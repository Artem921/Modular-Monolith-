using Carts.Domain.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Utils.Module;
namespace Carts.Infrastructure
{
    internal class CartInfrastructueModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<ICacheService,CacheService>();
            services.AddSingleton(provider =>
            {
                var configur = provider.GetRequiredService<IConfiguration>();
                var mongoSection = configur.GetSection("CartDbSettings");
                var connectionString = mongoSection.GetValue<string>("ConnectionStrings");
                var database = mongoSection.GetValue<string>("DatabaseName");

                var mongoClient = new MongoClient(connectionString);

                return mongoClient.GetDatabase(database);
            });
            services.AddStackExchangeRedisCache(options =>
            {
                options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
                {
                    ConnectTimeout = 10000,
                    AbortOnConnectFail = true,
                    EndPoints = { "localhost:90" }
                };
            });
        }
    }

}
