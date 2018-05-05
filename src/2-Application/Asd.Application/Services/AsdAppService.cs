namespace Asd.Application.Services
{
    using Asd.Domain.Core.Bus;
    using AutoMapper;
    using System;

    public abstract class AsdAppService
    {
        protected IAsdBus Bus { get; }
        protected IMapper Mapper { get; }
        protected AsdAppService(IAsdBus bus, IMapper mapper)
        {
            Bus = bus ?? throw new ArgumentNullException(nameof(bus));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}