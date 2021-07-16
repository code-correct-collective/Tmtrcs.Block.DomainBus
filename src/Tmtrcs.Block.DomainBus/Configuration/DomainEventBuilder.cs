namespace Tmtrcs.Block.DomainBus.Configuration
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Tmtrcs.Block.DomainBus.Events;

    /// <summary>
    /// Record <c>EventBuilder</c>.
    /// </summary>
    public sealed record DomainEventBuilder : IDomainEventBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventBuilder"/> class.
        /// </summary>
        public DomainEventBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventBuilder" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public DomainEventBuilder(InProcBusConfiguration configuration)
            : this()
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public InProcBusConfiguration Configuration { get; init; }

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <typeparam name="TEvent">The type of the t event.</typeparam>
        /// <typeparam name="TEventHandler">The type of the t event handler.</typeparam>
        /// <returns>A/an <c>IEventBuilder</c>.</returns>
        public IDomainEventBuilder AddEvent<TEvent, TEventHandler>()
            where TEvent : IDomainEvent
            where TEventHandler : class, IDomainEventHandler<TEvent>
        {
            this.Configuration.Services.AddScoped<INotificationHandler<TEvent>, TEventHandler>();

            return this;
        }
    }
}
