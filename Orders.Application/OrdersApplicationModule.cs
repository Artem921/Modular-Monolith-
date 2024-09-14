using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Orders.Mapping;
using Utils.Module;

namespace Orders.Application
{
    public class OrdersApplicationModule: Module
    {
        public override void Load(IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(OrdersApplicationModule).Assembly));
        services.AddInfrastructureMapping();
    }
}
}
