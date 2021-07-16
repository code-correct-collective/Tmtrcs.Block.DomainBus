namespace Tmtrcs.Block.DomainBus.Configuration
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Tmtrcs.Block.DomainBus.Queries;

    /// <summary>
    /// The query builder.
    /// Implements the <see cref="IDomainQueryBuilder" />.
    /// </summary>
    /// <seealso cref="IDomainQueryBuilder" />
    public class DomainQueryBuilder : IDomainQueryBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainQueryBuilder" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public DomainQueryBuilder(InProcBusConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public InProcBusConfiguration Configuration { get; init; }

        /// <summary>
        /// Adds the query.
        /// </summary>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <typeparam name="TQueryResponse">The type of the query response.</typeparam>
        /// <typeparam name="TQueryHandler">The type of the query handler.</typeparam>
        /// <returns>A/an <c>IQueryBuilder</c>.</returns>
        public IDomainQueryBuilder AddQuery<TQuery, TQueryResponse, TQueryHandler>()
            where TQuery : IDomainQuery<TQueryResponse>
            where TQueryHandler : class, IDomainQueryHandler<TQuery, TQueryResponse>
        {
            this.Configuration.Services.AddScoped<IRequestHandler<TQuery, TQueryResponse>, TQueryHandler>();
            return this;
        }
    }
}
