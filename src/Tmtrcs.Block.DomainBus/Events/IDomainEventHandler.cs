namespace Tmtrcs.Block.DomainBus.Events
{
    using MediatR;

    /// <summary>
    /// Interface <c>IEventHandler</c>
    /// Implements the <see cref="INotificationHandler{TEvent}" />.
    /// </summary>
    /// <typeparam name="TEvent">The type of the t event.</typeparam>
    /// <seealso cref="INotificationHandler{TEvent}" />
    public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
    {
    }
}
