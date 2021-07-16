namespace Tmtrcs.Block.DomainBus.Queries
{
    using MediatR;

    /// <summary>
    /// Interface <c>IQuery</c>
    /// Implements the <see cref="IRequest{TResponse}" />.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <seealso cref="IRequest{TResponse}" />
    public interface IDomainQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
