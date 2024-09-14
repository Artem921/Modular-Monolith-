using Microsoft.Extensions.DependencyInjection;
using Notification.Domain.Abstraction;
using Notification.Domain.Entities;
using Utils.Module;

namespace Notification.Infrastructure
{
    public class NotificationInfrastractionModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();

            services.Configure<EmailOptions>(Configuration.GetSection("EmailOptions"));
        }
    }
}
