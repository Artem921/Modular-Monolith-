using Microsoft.Extensions.DependencyInjection;
using Utils.Module;

namespace Notification.Controllers
{
    public class NotificationsControllerModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<NotificationsController>();
        }
    }
}
