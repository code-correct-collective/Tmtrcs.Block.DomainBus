namespace Tmtrcs.Block.DomainBus.Tests.Configuration
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Moq;

    using Tmtrcs.Block.DomainBus.Configuration;
    using Tmtrcs.Block.DomainBus.Tests.Commands.Stubs;

    using Xunit;

    /// <summary>
    /// Class <c>DomainCommandBuilderTests</c>.
    /// </summary>
    public class DomainCommandBuilderTests
    {
        /// <summary>
        /// Defines the test method TestAddCommandMethod.
        /// </summary>
        [Fact]
        public void TestAddCommandMethod()
        {
            var serviceCollectionMock = new Mock<IServiceCollection>(MockBehavior.Strict);
            serviceCollectionMock.Setup(s => s.Add(It.IsAny<ServiceDescriptor>())).Callback((ServiceDescriptor sd) =>
            {
                Assert.True(sd.ServiceType.IsAssignableFrom(typeof(IRequestHandler<Command, Unit>)));
                Assert.True(sd.ImplementationType.IsAssignableFrom(typeof(CommandHandler)));
            });

            var cmdBuilder = new DomainCommandBuilder(new InProcBusConfiguration { Services = serviceCollectionMock.Object });
            cmdBuilder.AddCommand<Command, CommandHandler>();

            serviceCollectionMock.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }
    }
}
