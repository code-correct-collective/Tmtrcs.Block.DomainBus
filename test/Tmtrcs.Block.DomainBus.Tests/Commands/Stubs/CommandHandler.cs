namespace Tmtrcs.Block.DomainBus.Tests.Commands.Stubs
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Tmtrcs.Block.DomainBus;

    /// <summary>
    /// Class CommandHandler.
    /// Implements the <see cref="IDomainCommandHandler{TCommand}" />.
    /// </summary>
    /// <seealso cref="IDomainCommandHandler{TCommand}" />
    [ExcludeFromCodeCoverage]
    public class CommandHandler : IDomainCommandHandler<Command>
    {
        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;Unit&gt;.</returns>
        public Task<Unit> Handle(Command request, CancellationToken cancellationToken) => Unit.Task;
    }
}
