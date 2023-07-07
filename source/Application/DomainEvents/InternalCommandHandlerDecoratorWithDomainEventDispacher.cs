using BuildingBlocks.Application.InternalCommands;

namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class InternalCommandHandlerDecoratorWithDomainEventDispacher<TInternalCommand> : IInternalCommandHandler<TInternalCommand>
        where TInternalCommand : InternalCommandBase
    {
        private readonly IInternalCommandHandler<TInternalCommand> _decoratedInternalCommandHandler;
        private readonly IDomainEventDispacher _domainEventDispacher;
        private readonly IDomainEventsAccessor _domainEventsAccessor;

        public InternalCommandHandlerDecoratorWithDomainEventDispacher(
            IInternalCommandHandler<TInternalCommand> decoratedInternalCommandHandler,
            IDomainEventDispacher domainEventDispacher,
            IDomainEventsAccessor domainEventsAccessor)
        {
            _decoratedInternalCommandHandler = decoratedInternalCommandHandler;
            _domainEventDispacher = domainEventDispacher;
            _domainEventsAccessor = domainEventsAccessor;
        }

        public async Task Handle(TInternalCommand internalCommand, CancellationToken cancellationToken)
        {
            await _decoratedInternalCommandHandler.Handle(internalCommand, cancellationToken);

            var domainEvents = _domainEventsAccessor.GetAllDomainEvents();

            _domainEventsAccessor.ClearAllDomainEvents();

            await _domainEventDispacher.Dispach(domainEvents, cancellationToken);
        }
    }
}
