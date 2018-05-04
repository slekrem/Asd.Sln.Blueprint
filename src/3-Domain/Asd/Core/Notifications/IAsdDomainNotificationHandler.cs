namespace Asd.Domain.Core.Notifications
{
    using Asd.Domain.Core.Events;
    using System.Collections.Generic;

    public interface IAsdDomainNotificationHandler<T> : IAsdHandler<T> where T : AsdMessage
    {
        IEnumerable<AsdDomainNotification> Notifications { get; }

        bool HasNotifications { get; }
    }
}