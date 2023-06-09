﻿using BuildingBlocks.Domain.BusinessRules;
using BuildingBlocks.Domain.DomainEvents;
using BuildingBlocks.Domain.ValueObjects;

namespace BuildingBlocks.Domain.Entities
{
    public abstract class Entity
    {
        internal abstract IReadOnlyCollection<DomainEvent> DomainEvents { get; }

        internal abstract void ClearDomainEvents();
    }

    public abstract class Entity<TEntityId, TDomainEvent> : Entity, IEntity
        where TEntityId : EntityId
        where TDomainEvent : DomainEvent
    {
        public TEntityId Id { get; }

        private List<TDomainEvent> _domainEvents = new List<TDomainEvent>();

        internal override IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Entity() { }

        protected Entity(TEntityId id)
        {
            if (id is null)
            {
                throw new EntityIdCannotBeNullException();
            }

            Id = id;
        }

        protected void Publish(TDomainEvent domainEvent)
        {
            if (domainEvent is null)
            {
                throw new DomainEventCannotBeNullException<TDomainEvent>();
            }

            _domainEvents.Add(domainEvent);
        }

        internal override void ClearDomainEvents() => _domainEvents.Clear();

        protected void CheckRule(IBusinessOperationRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessOperationRuleValidationException(rule);
            }
        }

        protected void CheckNulls(ValueObject valueObject)
        {
            if (valueObject is null)
            {
                throw new ValueObjectCannotBeNullException();
            }
        }

        protected void CheckNulls(params ValueObject[] valueObjects)
        {
            foreach (var valueObject in valueObjects)
            {
                CheckNulls(valueObject);
            }
        }
    }
}