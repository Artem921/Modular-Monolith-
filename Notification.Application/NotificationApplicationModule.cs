using Microsoft.Extensions.DependencyInjection;
using Utils.Module;

namespace Notification.Application
{
    public class NotificationApplicationModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(NotificationApplicationModule).Assembly));
        }
    }
}
