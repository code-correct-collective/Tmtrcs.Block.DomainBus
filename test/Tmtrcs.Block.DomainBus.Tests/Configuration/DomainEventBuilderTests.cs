namespace Tmtrcs.Block.DomainBus.Tests.Configuration
{
    using System.Diagnostics.CodeAnalysis;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Moq;

    using Tmtrcs.Block.DomainBus.Configuration;
    using Tmtrcs.Block.DomainBus.Tests.Events.Stubs;

    using Xunit;

    /// <summary>
    /// Class DomainEventBuilderTests.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DomainEventBuilderTests
    {
        /// <summary>
        /// Defines the test method AddEventMethodTest.
        /// </summary>
        [Fact]
        public void AddEventMethodTest()
        {
            var servicesMock = new Mock<IServiceCollection>(MockBehavior.Strict);
            servicesMock.Setup(s => s.Add(It.IsAny<ServiceDescriptor>())).Callback<ServiceDescriptor>(sd =>
              {
                  Assert.True(sd.ImplementationType.IsAssignableFrom(typeof(StubDomainEventHandler)));
                  Assert.True(sd.ServiceType.IsAssignableFrom(typeof(INotificationHandler<StubDomainEvent>)));
              });

            var builder = new DomainEventBuilder(new InProcBusConfiguration(servicesMock.Object));
            builder.AddEvent<StubDomainEvent, StubDomainEventHandler>();

            servicesMock.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }
    }
}
