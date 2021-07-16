namespace Tmtrcs.Block.DomainBus.Configuration
{
    using Tmtrcs.Block.DomainBus.Queries;

    /// <summary>
    /// Interface <c>IQueryBuilder</c>.
    /// </summary>
    public interface IDomainQueryBuilder
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public InProcBusConfiguration Configuration { get; }

        /// <summary>
        /// Adds the query.
        /// </summary>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <typeparam name="TQueryResponse">The type of the query response.</typeparam>
        /// <typeparam name="TQueryHandler">The type of the query handler.</typeparam>
        /// <returns>A/an <c>IQueryBuilder</c>.</returns>
        IDomainQueryBuilder AddQuery<TQuery, TQueryResponse, TQueryHandler>()
            where TQuery : IDomainQuery<TQueryResponse>
            where TQueryHandler : class, IDomainQueryHandler<TQuery, TQueryResponse>;
    }
}
