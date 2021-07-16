namespace Tmtrcs.Block.DomainBus.Tests.Events.Stubs
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    using Tmtrcs.Block.DomainBus.Events;

    /// <summary>
    /// Class StubDomainEventHandler.
    /// Implements the <see cref="DomainEvents.IDomainEventHandler{T}" />.
    /// </summary>
    /// <seealso cref="DomainEvents.IDomainEventHandler{T}" />
    [ExcludeFromCodeCoverage]
    public class StubDomainEventHandler : IDomainEventHandler<StubDomainEvent>
    {
        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException">Not Implemented.</exception>
        public Task Handle(StubDomainEvent notification, CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
