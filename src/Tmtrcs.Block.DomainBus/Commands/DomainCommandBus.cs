namespace Tmtrcs.Block.DomainBus
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The command bus.
    /// </summary>
    public class DomainCommandBus : IDomainCommandBus
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<DomainCommandBus> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainCommandBus" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="logger">The logger.</param>
        public DomainCommandBus(IMediator mediator, ILogger<DomainCommandBus> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the t command.</typeparam>
        /// <param name="command">The command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A/an <c>Task</c>.</returns>
        public Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : IDomainCommand
        {
            this.logger.LogDebug("Executing {@command}", command);
            return this.mediator.Send(command, cancellationToken);
        }
    }
}
