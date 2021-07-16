namespace Tmtrcs.Block.DomainBus.Queries
{
    using System;

    /// <summary>
    /// Class QueryBase.
    /// Implements the <see cref="Tmtrcs.Block.DomainBus.Queries.IDomainQuery{TResponse}" />.
    /// </summary>
    /// <typeparam name="TResponse">The type of the t response.</typeparam>
    /// <seealso cref="Tmtrcs.Block.DomainBus.Queries.IDomainQuery{TResponse}" />
    public record QueryBase<TResponse> : IDomainQuery<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBase{TResponse}"/> class.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        public QueryBase(string correlationId)
        {
            this.CorrelationId = correlationId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBase{TResponse}"/> class.
        /// </summary>
        public QueryBase()
            : this(Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// Gets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        public string CorrelationId { get; init; }
    }
}
