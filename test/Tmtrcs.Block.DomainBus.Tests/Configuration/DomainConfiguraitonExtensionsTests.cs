namespace Tmtrcs.Block.DomainBus.Tests.Configuration
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Moq;

    using Tmtrcs.Block.DomainBus;
    using Tmtrcs.Block.DomainBus.Configuration;

    using Xunit;

    /// <summary>
    /// Class DomainConfiguraitonExtensionsTests.
    /// </summary>
    public class DomainConfiguraitonExtensionsTests
    {
        /// <summary>
        /// Defines the test method AddCommandsMethodTest.
        /// </summary>
        [Fact]
        public void AddCommandsMethodTest()
        {
            var serviceCollectionMock = new Mock<IServiceCollection>(MockBehavior.Strict);

            serviceCollectionMock.Setup(s => s.Add(It.IsAny<ServiceDescriptor>())).Callback((ServiceDescriptor sp) =>
            {
                var scopedServiceTypes = new[]
                {
                    typeof(IMediator),
                    typeof(IDomainCommandBus),
                };

                var implementationTypes = new[]
                {
                    typeof(Mediator),
                    typeof(DomainCommandBus),
                };

                if (sp.Lifetime == ServiceLifetime.Transient)
                {
                    Assert.True(sp.ServiceType.IsAssignableFrom(typeof(ServiceFactory)));
                }

                if (sp.Lifetime == ServiceLifetime.Scoped)
                {
                    Assert.Contains(scopedServiceTypes, sst => sp.ServiceType.IsAssignableFrom(sst));
                    Assert.Contains(implementationTypes, it => sp.ImplementationType.IsAssignableFrom(it));
                }
            });

            var builder = serviceCollectionMock.Object.AddInProcBus().AddCommands();

            serviceCollectionMock.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Exactly(3));
        }
    }
}
