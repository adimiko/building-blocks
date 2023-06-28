using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    public abstract class DomainEventPublication<TDomainEvent> : IDomainEventPublication<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
        private List<Func<TDomainEvent, InternalCommandBase>> _internalCommandFactiories = new List<Func<TDomainEvent, InternalCommandBase>>();

        protected void Add(Func<TDomainEvent, InternalCommandBase> internalCommandFactory)
        {
            if (internalCommandFactory is null)
            {
                throw new InternalCommandFactoryCannotBeNullException();
            }
            
            _internalCommandFactiories.Add(internalCommandFactory);
        }

        public IReadOnlyCollection<InternalCommandBase> GetInternalCommands(TDomainEvent domainEvent)
        {
            if (domainEvent is null)
            {
                throw new DomainEventCannotBeNullException();
            }

            var list = new List<InternalCommandBase>();

            foreach (var factory in _internalCommandFactiories)
            {
                var internalCommand = factory(domainEvent);

                list.Add(internalCommand);
            }

            return list.AsReadOnly();
        }
    }
}
