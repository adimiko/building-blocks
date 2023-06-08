using BuildingBlocks.Domain.DomainEvents;
using BuildingBlocks.Domain.Entities;

namespace BuildingBlocks.Domain.AggregateRoots
{
    public abstract class AggregateRoot<TAggregateRootId, TDomainEvent> : Entity<TAggregateRootId, TDomainEvent>, IAggregateRoot
        where TAggregateRootId : AggregateRootId
        where TDomainEvent : DomainEvent
    {
        private bool _isVersionIncrementing = false;

        public AggregateRootVersion Version { get; private set; } = AggregateRootVersion.Init();

        protected void IncrementVersion()
        {
            CheckIncrementing();

            lock (Version)
            {
                CheckIncrementing();

                _isVersionIncrementing = true;
;
                Version = Version.Increment();

                _isVersionIncrementing = false;
            } 
        }

        private void CheckIncrementing()
        {
            if (_isVersionIncrementing)
            {
                throw new ConcurrencyException($"{GetType().Name} with id '{Id}' is updating by another process");
            }
        }
    }
}