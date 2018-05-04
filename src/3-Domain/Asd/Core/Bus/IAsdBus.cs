namespace Asd.Domain.Core.Bus
{
    using Asd.Domain.Core.Commands;
    using Asd.Domain.Core.Events;

    public interface IAsdBus
    {
        void SendCommand<T>(T command) where T : AsdCommand;

        void RaiseEvent<T>(T @event) where T : AsdEvent;
    }
}