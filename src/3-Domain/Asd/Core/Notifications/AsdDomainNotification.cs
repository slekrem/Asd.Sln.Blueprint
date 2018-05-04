namespace Asd.Domain.Core.Notifications
{
    using Asd.Domain.Core.Events;
    using System;

    public class AsdDomainNotification : AsdEvent
    {
        public Guid DomainNotificationId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public int Version { get; private set; }

        public AsdDomainNotification(string key, string value)
        {
            Key = string.IsNullOrWhiteSpace(key) ? throw new ArgumentNullException(nameof(key)) : key;
            Value = string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(nameof(value)) : value;
            Version = 1;
            DomainNotificationId = Guid.NewGuid();
        }
    }
}