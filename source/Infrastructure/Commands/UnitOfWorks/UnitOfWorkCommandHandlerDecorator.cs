using BuildingBlocks.Application.Commands;

namespace BuildingBlocks.Infrastructure.Commands.UnitOfWorks
{
    internal class UnitOfWorkCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : CommandBase
    {
        private readonly ICommandHandler<TCommand> _decoratedHandler;

        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<TCommand> decoratedHandler,
            IUnitOfWork unitOfWork)
        {
            _decoratedHandler = decoratedHandler;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TCommand command, CancellationToken cancellationToken)
        {
            await _decoratedHandler.Handle(command, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);
        }
    }
}
