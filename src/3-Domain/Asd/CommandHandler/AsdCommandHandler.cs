namespace Asd.Domain.CommandHandler
{
    using Asd.Domain.Core.Bus;
    using Asd.Domain.Core.Commands;
    using Asd.Domain.Core.Notifications;
    using Asd.Domain.Interfaces;
    using System;

    public abstract class AsdCommandHandler
    {
        private readonly IAsdUnitOfWork _unitOfWork;
        private readonly IAsdBus _bus;
        private readonly IAsdDomainNotificationHandler<AsdDomainNotification> _notifications;

        protected IAsdBus Bus => _bus;

        public AsdCommandHandler(IAsdUnitOfWork unitOfWork, IAsdBus bus, IAsdDomainNotificationHandler<AsdDomainNotification> notifications)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _notifications = notifications ?? throw new ArgumentNullException(nameof(notifications));
        }

        protected void NotifyValidationErrors(AsdCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            foreach (var error in command.ValidationResult.Errors)
                _bus.RaiseEvent(new AsdDomainNotification(command.MessageType, error.ErrorMessage));
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications) return false;
            if (_unitOfWork.Commit().Success) return true;
            _bus.RaiseEvent(new AsdDomainNotification(nameof(Commit), "something goes wrong ..."));
            return false;
        }
    }
}