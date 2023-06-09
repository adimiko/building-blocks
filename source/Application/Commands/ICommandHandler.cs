﻿using MediatR;

namespace BuildingBlocks.Application.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : CommandBase
    {
        new Task Handle(TCommand command, CancellationToken cancellationToken);
    }
}
