namespace Tmtrcs.Block.DomainBus.Events
{
    using System.Reflection;

    /// <summary>
    /// Record DomainEventBase.
    /// Implements the <see cref="IDomainEvent" />.
    /// </summary>
    /// <seealso cref="IDomainEvent" />
    public record DomainEventBase : IDomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventBase"/> class.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        public DomainEventBase(string correlationId)
        {
            this.CorrelationId = correlationId;
        }

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        public string EventType => $"{this.GetType().GetTypeInfo().FullName}, {this.GetType().Assembly.GetName().Name}";

        /// <summary>
        /// Gets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        public string CorrelationId { get; init; }
    }
}
