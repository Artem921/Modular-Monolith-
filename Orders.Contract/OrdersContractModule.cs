using Microsoft.Extensions.DependencyInjection;
using Utils.Module;

namespace Orders.Contract
{
    public class OrdersContractModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<IOrdersContract, OrdersContract>();
        }

    }
}
