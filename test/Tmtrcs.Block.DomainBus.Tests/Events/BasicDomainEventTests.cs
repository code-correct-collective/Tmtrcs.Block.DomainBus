namespace Tmtrcs.Block.DomainBus.Tests.Events
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Tmtrcs.Block.DomainBus.Tests.Events.Stubs;

    using Xunit;

    /// <summary>
    /// Class BasicDomainEventTests.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BasicDomainEventTests
    {
        /// <summary>
        /// Defines the test method TestDomainProperties.
        /// </summary>
        [Fact]
        public void TestDomainProperties()
        {
            var id = Guid.NewGuid().ToString();
            var id2 = Guid.NewGuid().ToString();
            const string eventType = "Tmtrcs.Block.DomainBus.Tests.Events.Stubs.StubDomainEvent, Tmtrcs.Block.DomainBus.Tests";

            var d = new StubDomainEvent(id);
            var d2 = new StubDomainEvent(id2);

            Assert.Equal(id, d.CorrelationId);
            Assert.Equal(id2, d2.CorrelationId);
            Assert.Equal(eventType, d.EventType);
        }
    }
}
