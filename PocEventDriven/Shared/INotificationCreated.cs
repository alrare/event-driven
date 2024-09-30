using System.Data;

namespace Shared.Comminication
{
    public interface INotificationCreated
    {
        DataSetDateTime NotificationDate { get; set; }
        string NotificationMessage { get; set; }
        NotificationType NotificationType { get; set; }
    }
}
