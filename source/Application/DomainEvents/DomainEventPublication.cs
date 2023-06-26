using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    public abstract class DomainEventPublication<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
        private List<Func<TDomainEvent, InternalCommandBase>> _internalCommandFactiories = new List<Func<TDomainEvent, InternalCommandBase>>();

        protected void Add(Func<TDomainEvent, InternalCommandBase> createInternalCommandBasedOnDomainEvent)
        {
            //cannot be null
            ArgumentNullException.ThrowIfNull(createInternalCommandBasedOnDomainEvent, nameof(createInternalCommandBasedOnDomainEvent));
            
            _internalCommandFactiories.Add(createInternalCommandBasedOnDomainEvent);
        }

        internal IReadOnlyCollection<InternalCommandBase> GetInternalCommands(TDomainEvent domainEvent)
        {
            // cannot be null
            ArgumentNullException.ThrowIfNull(domainEvent, nameof(domainEvent));

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
