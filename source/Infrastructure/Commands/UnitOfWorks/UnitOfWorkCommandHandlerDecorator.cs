using BuildingBlocks.Application.Commands;
using BuildingBlocks.Application.DomainEvents;

namespace BuildingBlocks.Infrastructure.Commands.UnitOfWorks
{
    internal class UnitOfWorkCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : CommandBase
    {
        private readonly ICommandHandler<TCommand> _decoratedHandler;

        private readonly IDomainEventDispacher _domainEventDispacher;

        private readonly IDomainEventsAccessor _domainEventsAccessor;

        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<TCommand> decoratedHandler,
            IDomainEventDispacher domainEventDispacher,
            IDomainEventsAccessor domainEventsAccessor,
            IUnitOfWork unitOfWork)
        {
            _decoratedHandler = decoratedHandler;
            _domainEventDispacher = domainEventDispacher;
            _domainEventsAccessor = domainEventsAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TCommand command, CancellationToken cancellationToken)
        {
            await _decoratedHandler.Handle(command, cancellationToken);

            var domainEvents = _domainEventsAccessor.GetAllDomainEvents();

            _domainEventsAccessor.ClearAllDomainEvents();

            await _domainEventDispacher.Dispach(domainEvents, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);
        }
    }
}
