namespace Tmtrcs.Block.DomainBus.Queries
{
    using MediatR;

    /// <summary>
    /// Interface <c>IQueryHandler</c>
    /// Implements the <see cref="IRequestHandler{TQuery, TResponse}" />.
    /// </summary>
    /// <typeparam name="TQuery">The type of the t query.</typeparam>
    /// <typeparam name="TResponse">The type of the t response.</typeparam>
    /// <seealso cref="IRequestHandler{TQuery, TResponse}" />
    public interface IDomainQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IDomainQuery<TResponse>
    {
    }
}
