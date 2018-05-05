namespace Asd.Infra.CrossCutting.Bus
{
    using Asd.Domain.Core.Bus;
    using Asd.Domain.Core.Commands;
    using Asd.Domain.Core.Events;
    using Asd.Domain.Core.Notifications;
    using System;

    public class AsdInMemoryBus : IAsdBus
    {
        private readonly IAsdIEventStore _eventStore;
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container { get { return ContainerAccessor(); } }

        public AsdInMemoryBus(IAsdIEventStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public void RaiseEvent<T>(T @event) where T : AsdEvent
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));
            if (!@event.MessageType.Equals(nameof(AsdDomainNotification)))
                _eventStore.Save(@event);
            Publish(@event);
        }

        public void SendCommand<T>(T command) where T : AsdCommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            Publish(command);
        }

        private static void Publish<T>(T message) where T : AsdMessage
        {
            if (Container == null) return;
            var handler = Container.GetService(message.MessageType.Equals(nameof(AsdDomainNotification))
                ? typeof(IAsdDomainNotificationHandler<T>)
                : typeof(IAsdHandler<T>));
            ((IAsdHandler<T>)handler).Handle(message);
        }
    }
}