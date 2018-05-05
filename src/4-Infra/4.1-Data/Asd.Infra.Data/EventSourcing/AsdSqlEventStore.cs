namespace Asd.Infra.Data.EventSourcing
{
    using Asd.Domain.Core.Events;
    using Asd.Infra.Data.Interfaces;
    using Newtonsoft.Json;
    using System;

    public class AsdSqlEventStore : IAsdIEventStore
    {
        private readonly IAsdEventStoreRepository _repository;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public AsdSqlEventStore(IAsdEventStoreRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new AsdEventStoreContractResolver()
            };
        }

        public void Save<T>(T @event) where T : AsdEvent
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));
            _repository.Store(new AsdStoredEvent(@event, JsonConvert.SerializeObject(@event.AsdEntity, _jsonSerializerSettings), "Anonymous"));
        }
    }
}