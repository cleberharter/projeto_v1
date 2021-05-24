using Examples.Charge.Core.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Charge.Application.Common
{
    public class ApplicationDataResult<T>
    {
        public List<Notification> Errors { get; }

        public T Data { get; }

        public readonly bool IsSuccess = true;

        private ApplicationDataResult(List<Notification> errors)
        {
            Errors = errors;
            IsSuccess = false;
        }

        private ApplicationDataResult(T data) => Data = data;

        private ApplicationDataResult()
        {
        }

        public static ApplicationDataResult<T> FactoryFromNotificationContext(NotificationContext notificationContext)
        {
            return new ApplicationDataResult<T>(notificationContext.Notifications.ToList());
        }

        public static ApplicationDataResult<T> FactoryFromData(T data)
        {
            return new ApplicationDataResult<T>(data);
        }

        public static ApplicationDataResult<T> FactoryFromEmpty()
        { 
            return new ApplicationDataResult<T>();
        }
    }
}
