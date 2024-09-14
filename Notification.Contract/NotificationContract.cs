
using MediatR;
using Notification.Application.Notification.Commands;

namespace Notification.Contract
{
    internal class NotificationContract : INotificationContract
    {
        private readonly IMediator mediator;

        public NotificationContract(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task SendNotification(string email, string subject, string message,int id)
        {
            await mediator.Send(new SendEmailOrderNotification(email, subject, message,id));
        }
    }
}
