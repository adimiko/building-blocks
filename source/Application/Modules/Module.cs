using BuildingBlocks.Application.Commands;
using BuildingBlocks.Application.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Application.Modules
{
    public abstract class Module : IModule
    {
        private IServiceProvider _container;

        private void SetContainer(IServiceProvider container)
        {
            if (container is null)
            {
                throw new ContainerCannotBeNullException();
            }

            if (_container is not null)
            {
                throw new ContainerHasAlreadyBeenSetUpException();
            }

            _container = container;
        }

        public async Task Execute(CommandBase command, CancellationToken cancellationToken = default)
        {
            using (var scope = _container.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(command, cancellationToken);
            }
        }

        public async Task<TResult> Execute<TResult>(QueryBase<TResult> query, CancellationToken cancellationToken = default)
            where TResult : DataTransferObject
        {
            using (var scope = _container.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                return await mediator.Send(query, cancellationToken);
            }
        }
    }
}
