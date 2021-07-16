namespace Tmtrcs.Block.DomainBus.Events
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface <c>IEventBus</c>.
    /// </summary>
    public interface IDomainEventBus
    {
        /// <summary>
        /// Publishes the asynchronous.
        /// </summary>
        /// <typeparam name="TEvent">The type of the t event.</typeparam>
        /// <param name="events">The events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A/an <c>Task</c>.</returns>
        Task PublishAsync<TEvent>(IEnumerable<TEvent> events, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent;

        /// <summary>
        /// Publishes the asynchronous.
        /// </summary>
        /// <typeparam name="TEvent">The type of the t event.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="events">The events.</param>
        /// <returns>A/an <c>Task</c>.</returns>
        Task PublishAsync<TEvent>(
            CancellationToken cancellationToken = default,
            params TEvent[] events)
            where TEvent : IDomainEvent;
    }
}
