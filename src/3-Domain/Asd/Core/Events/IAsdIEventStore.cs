namespace Asd.Domain.Core.Events
{
    public interface IAsdIEventStore
    {
        void Save<T>(T @event) where T : AsdEvent;
    }
}