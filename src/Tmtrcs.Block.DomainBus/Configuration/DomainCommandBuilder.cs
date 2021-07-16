namespace Tmtrcs.Block.DomainBus.Configuration
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Tmtrcs.Block.DomainBus;

    /// <summary>
    /// Class <c>CommandBuilder</c>.
    /// Implements the <see cref="IDomainCommandBuilder" />.
    /// </summary>
    /// <seealso cref="IDomainCommandBuilder" />
    public sealed record DomainCommandBuilder : IDomainCommandBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainCommandBuilder" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public DomainCommandBuilder(InProcBusConfiguration configuration) => this.Configuration = configuration;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public InProcBusConfiguration Configuration { get; init; }

        /// <inheritdoc />
        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the t command.</typeparam>
        /// <typeparam name="TCommandHandler">The type of the t command handler.</typeparam>
        /// <returns>A/an <c>ICommandBuilder</c>.</returns>
        public IDomainCommandBuilder AddCommand<TCommand, TCommandHandler>()
            where TCommand : IDomainCommand
            where TCommandHandler : class, IDomainCommandHandler<TCommand>
        {
            this.Configuration.Services.AddScoped<IRequestHandler<TCommand, Unit>, TCommandHandler>();

            return this;
        }
    }
}
