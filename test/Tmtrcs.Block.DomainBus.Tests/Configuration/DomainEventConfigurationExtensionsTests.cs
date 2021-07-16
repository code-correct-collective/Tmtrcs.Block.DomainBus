namespace Tmtrcs.Block.DomainBus.Tests.Configuration
{
    using System.Diagnostics.CodeAnalysis;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Moq;

    using Tmtrcs.Block.DomainBus.Configuration;
    using Tmtrcs.Block.DomainBus.Events;

    using Xunit;

    /// <summary>
    /// Class DomainEventConfigurationExtensionsTests.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DomainEventConfigurationExtensionsTests
    {
        /// <summary>
        /// Defines the test method AddEventsTest.
        /// </summary>
        [Fact]
        public void AddEventsTest()
        {
            var scopedTypes = new[]
            {
                new { Service = typeof(IMediator), Implementation = typeof(Mediator) },
                new { Service = typeof(IDomainEventBus), Implementation = typeof(DomainEventBus) },
            };

            var servicesMock = new Mock<IServiceCollection>(MockBehavior.Strict);

            servicesMock.Setup(s => s.Add(It.IsAny<ServiceDescriptor>())).Callback<ServiceDescriptor>(sd =>
            {
                if (sd.Lifetime == ServiceLifetime.Scoped)
                {
                    Assert.Contains(scopedTypes, st => sd.ServiceType.IsAssignableFrom(st.Service) && sd.ImplementationType.IsAssignableFrom(st.Implementation));
                }
                else
                {
                    Assert.True(sd.ServiceType.IsAssignableFrom(typeof(ServiceFactory)));
                }
            });

            servicesMock.Object.AddInProcBus().AddEvents();

            servicesMock.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Exactly(3));
        }
    }
}
