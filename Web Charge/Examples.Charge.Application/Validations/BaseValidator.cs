using Examples.Charge.Core.Notifications;

namespace Examples.Charge.Application.Validations
{
    public class BaseValidator
    {
        protected Notification CreateNotification(string key, string message)
        {
           return new Notification(key, message);
        }
    }
}
