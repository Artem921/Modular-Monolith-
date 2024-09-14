using Microsoft.Extensions.DependencyInjection;
using Utils.Module;

namespace Notification.Contract
{
    public class NotificationContractModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<INotificationContract, NotificationContract>();
        }
    }
}
