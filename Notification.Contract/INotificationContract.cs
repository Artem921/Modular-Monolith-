namespace Notification.Contract
{
    public interface INotificationContract
    {
        Task SendNotification(string email, string subject, string message,int id);
       
    }
}
