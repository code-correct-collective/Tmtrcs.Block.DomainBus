namespace Tmtrcs.Block.DomainBus.Tests.Events.Stubs
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Tmtrcs.Block.DomainBus.Events;

    /// <summary>
    /// Class StubDomainEvent.
    /// Implements the <see cref="Blocks.DomainEvents.BasicDomainEvent{T}" />.
    /// </summary>
    /// <seealso cref="Blocks.DomainEvents.BasicDomainEvent{T}" />
    [ExcludeFromCodeCoverage]
    public record StubDomainEvent : DomainEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StubDomainEvent" /> class.
        /// </summary>
        public StubDomainEvent()
            : this(Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StubDomainEvent"/> class.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        public StubDomainEvent(string correlationId)
            : base(correlationId)
        {
        }
    }
}
