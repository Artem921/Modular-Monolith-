using Microsoft.Extensions.DependencyInjection;
using Product.Application.Mapping;
using Utils.Module;

namespace Product.Application
{
    public class ProductApplicationModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ProductApplicationModule).Assembly));
            services.AddInfrastructureMapping();
        }
    }
}
