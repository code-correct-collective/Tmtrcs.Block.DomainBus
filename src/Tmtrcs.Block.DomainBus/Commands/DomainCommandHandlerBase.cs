namespace Tmtrcs.Block.DomainBus
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    /// <summary>
    /// The abstract Domain Command Handler Base class.
    /// </summary>
    /// <typeparam name="TCommand">The command to handle.</typeparam>
    public abstract class DomainCommandHandlerBase<TCommand> : IDomainCommandHandler<TCommand>
        where TCommand : IDomainCommand
    {
        /// <inheritdoc/>
        async Task<Unit> IRequestHandler<TCommand, Unit>.Handle(TCommand request, CancellationToken cancellationToken)
        {
            await this.Handle(request, cancellationToken).ConfigureAwait(false);

            return Unit.Value;
        }

        /// <summary>
        /// Handle the specified command.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected abstract Task Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
