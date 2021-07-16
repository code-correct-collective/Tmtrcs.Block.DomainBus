namespace Tmtrcs.Block.DomainBus
{
    using System;

    /// <summary>
    /// Record DomainCommandBase.
    /// Implements the <see cref="IDomainCommand" />.
    /// </summary>
    /// <seealso cref="IDomainCommand" />
    public abstract record DomainCommandBase(string CorrelationId) : IDomainCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainCommandBase"/> class.
        /// </summary>
        protected DomainCommandBase()
            : this(Guid.NewGuid().ToString())
        {
        }
    }
}
