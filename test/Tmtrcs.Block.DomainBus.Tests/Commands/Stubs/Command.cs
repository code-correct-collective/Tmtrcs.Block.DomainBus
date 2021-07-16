namespace Tmtrcs.Block.DomainBus.Tests.Commands.Stubs
{
    using System.Diagnostics.CodeAnalysis;

    using Tmtrcs.Block.DomainBus;

    /// <summary>
    /// Record Command.
    /// Implements the <see cref="DomainCommands.IDomainCommand" />.
    /// </summary>
    /// <seealso cref="DomainCommands.IDomainCommand" />
    [ExcludeFromCodeCoverage]
    public record Command : DomainCommandBase
    {
    }
}
