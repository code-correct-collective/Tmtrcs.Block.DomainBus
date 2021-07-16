namespace Tmtrcs.Block.DomainBus.Configuration
{
    using Tmtrcs.Block.DomainBus;

    /// <summary>
    /// Interface <c>ICommandBuilder</c>.
    /// </summary>
    public interface IDomainCommandBuilder
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        InProcBusConfiguration Configuration { get;  }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the t command.</typeparam>
        /// <typeparam name="TCommandHandler">The type of the t command handler.</typeparam>
        /// <returns>A/an <c>ICommandBuilder</c>.</returns>
        IDomainCommandBuilder AddCommand<TCommand, TCommandHandler>()
            where TCommand : IDomainCommand
            where TCommandHandler : class, IDomainCommandHandler<TCommand>;
    }
}
