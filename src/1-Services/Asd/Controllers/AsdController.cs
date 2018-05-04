namespace Asd.Service.Controllers
{
    using Asd.Domain.Core.Notifications;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public abstract class AsdController : Controller
    {
        private readonly IAsdDomainNotificationHandler<AsdDomainNotification> _notifications;
        public bool IsValidOperation { get { return !_notifications.HasNotifications; } }

        public AsdController(IAsdDomainNotificationHandler<AsdDomainNotification> notifications)
        {
            _notifications = notifications ?? throw new ArgumentNullException(nameof(notifications));
        }
    }
}
