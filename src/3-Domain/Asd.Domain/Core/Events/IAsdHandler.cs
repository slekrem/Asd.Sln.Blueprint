namespace Asd.Domain.Core.Events
{
    public interface IAsdHandler<in T> where T : AsdMessage
    {
        void Handle(T message);
    }
}