namespace Tmtrcs.Block.DomainBus.Configuration
{
    using Tmtrcs.Block.DomainBus.Events;

    /// <summary>
    /// Interface <c>IEventBuilder</c>.
    /// </summary>
    public interface IDomainEventBuilder
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        InProcBusConfiguration Configuration { get;  }

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <typeparam name="TEvent">The type of the t event.</typeparam>
        /// <typeparam name="TEventHandler">The type of the t event handler.</typeparam>
        /// <returns>A/an <c>IEventBuilder</c>.</returns>
        IDomainEventBuilder AddEvent<TEvent, TEventHandler>()
            where TEvent : IDomainEvent
            where TEventHandler : class, IDomainEventHandler<TEvent>;
    }
}
