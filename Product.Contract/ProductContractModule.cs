using Microsoft.Extensions.DependencyInjection;
using Module = Utils.Module.Module;

namespace Product.Contract
{
    public class ProductContractModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<IProductContract, ProductContract>();
        }
    }
}
