using Microsoft.Extensions.DependencyInjection;
using Orders.Domain.Abstraction;
using Orders.Infrastructure.Repositories;
using Utils.Module;

namespace Orders.Infrastructure
{
    public class OrdersInfrastructureModule : Module
    {      
        public override void Load(IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IOrdersRepository,OrdersRepository>();
        }
    }
}
