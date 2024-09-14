using Microsoft.Extensions.DependencyInjection;
using Utils.Module;

namespace Carts.Contract
{
    public class CartContractModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<ICartContract, CartContract>();
        }
    }
}
