namespace Tmtrcs.Block.DomainBus.Events
{
    using System.Reflection;

    /// <summary>
    /// Record DomainEventBase.
    /// Implements the <see cref="IDomainEvent" />.
    /// </summary>
    /// <seealso cref="IDomainEvent" />
    public record DomainEventBase(string CorrelationId) : IDomainEvent
    {
        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        public string EventType => $"{this.GetType().GetTypeInfo().FullName}, {this.GetType().Assembly.GetName().Name}";
    }
}
