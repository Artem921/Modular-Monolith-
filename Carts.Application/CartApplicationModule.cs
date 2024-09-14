using Carts.Application.Carts.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Utils.Module;

namespace Carts.Application
{
    public class CartApplicationModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CartApplicationModule).Assembly));
            services.AddInfrastructureMapping();
        }
    }
}
