using MediatR;
using Notification.Domain.Entities;

namespace Notification.Application.Notification.Commands
{
    internal record SendEmailOrderNotification(string Email,string Subject,string Message,int Id) : INotification;
    
}
