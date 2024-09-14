using MediatR;
using Notification.Domain.Abstraction;
using Orders.Contract;

namespace Notification.Application.Notification.Commands
{
    internal class SendEmailOrderHandler : INotificationHandler<SendEmailOrderNotification>
    {
        private readonly IEmailService emailService;
        private readonly IOrdersContract ordersContract;
        public SendEmailOrderHandler(IEmailService emailService, IOrdersContract ordersContract)
        {
            this.emailService = emailService;
            this.ordersContract = ordersContract;
        }

        public async Task Handle(SendEmailOrderNotification notification, CancellationToken cancellationToken)
        {
            var id = await ordersContract.GetIdByOrderAsync(notification.Id);
            await emailService.SendEmailAsync(notification.Email,"Вашь заказ", $"Вашь заказ под номером {id} готов. Можите приехать по адрессу Городской округ Щёлково, база «Байкал» ");

            await Task.CompletedTask;
        }
    }
}
