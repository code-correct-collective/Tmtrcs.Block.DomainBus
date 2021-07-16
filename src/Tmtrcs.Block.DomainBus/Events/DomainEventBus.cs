namespace Tmtrcs.Block.DomainBus.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class <c>EventBus</c>.
    /// Implements the <see cref="IDomainEventBus" />.
    /// </summary>
    /// <seealso cref="IDomainEventBus" />
    public class DomainEventBus : IDomainEventBus
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<DomainEventBus> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventBus" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="logger">The logger.</param>
        public DomainEventBus(IMediator mediator, ILogger<DomainEventBus> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        /// <summary>
        /// Publishes the asynchronous.
        /// </summary>
        /// <typeparam name="TEvent">The type of the t event.</typeparam>
        /// <param name="events">The events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A/an <c>Task</c>.</returns>
        public async Task PublishAsync<TEvent>(IEnumerable<TEvent> events, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent
        {
            var eventList = events.ToList();
            if (eventList.Count == 0)
            {
                throw new ArgumentException("Must publish at least one event", nameof(events));
            }

            this.logger.LogDebug("Raising {count} events", eventList.Count);
            var tasks = new List<Task>();
            foreach (var @event in eventList)
            {
                this.logger.LogDebug("Raising event {@event}", @event);
                tasks.Add(this.mediator.Publish(@event, cancellationToken));
            }

            await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
        }

        /// <summary>
        /// Publishes the asynchronous.
        /// </summary>
        /// <typeparam name="TEvent">The type of the t event.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="events">The events.</param>
        /// <returns>A/an <c>Task</c>.</returns>
        public Task PublishAsync<TEvent>(
            CancellationToken cancellationToken = default,
            params TEvent[] events)
            where TEvent : IDomainEvent
        {
            if (events.Length == 0)
            {
                throw new ArgumentException("Must publish at least one event", nameof(events));
            }

            return this.PublishAsync(events.AsEnumerable(), cancellationToken);
        }
    }
}
