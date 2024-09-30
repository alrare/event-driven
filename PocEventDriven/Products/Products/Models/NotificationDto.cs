using Shared;

namespace Products.Models
{
    public class NotificationDto
    {
        public DateTime NotificationDate { get; set; }
        public string NotificationMessage { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
