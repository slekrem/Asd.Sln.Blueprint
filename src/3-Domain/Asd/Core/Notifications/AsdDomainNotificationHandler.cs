namespace Asd.Domain.Core.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AsdDomainNotificationHandler : IAsdDomainNotificationHandler<AsdDomainNotification>
    {
        public IEnumerable<AsdDomainNotification> Notifications { get; private set; }

        public bool HasNotifications => Notifications.ToList().Any();

        public AsdDomainNotificationHandler() => Notifications = new List<AsdDomainNotification>();

        public void Handle(AsdDomainNotification message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
        }
    }
}