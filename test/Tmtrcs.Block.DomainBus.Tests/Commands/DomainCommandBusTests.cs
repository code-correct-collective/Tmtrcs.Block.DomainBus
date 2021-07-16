namespace Tmtrcs.Block.DomainBus.Tests.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.Extensions.Logging;

    using Moq;

    using Tmtrcs.Block.DomainBus;
    using Tmtrcs.Block.DomainBus.Tests.Commands.Stubs;

    using Xunit;

    /// <summary>
    /// Class DomainCommandBus.
    /// </summary>
    public class DomainCommandBusTests
    {
        /// <summary>
        /// Defines the test method ExecuteAsyncMethodTest.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task ExecuteAsyncMethodTest()
        {
            var command = new Command();
            var loggerMock = new Mock<ILogger<DomainCommandBus>>(MockBehavior.Loose);
            var mediatorMock = new Mock<IMediator>(MockBehavior.Strict);
            mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>())).Returns(Unit.Task);

            var bus = new DomainCommandBus(mediatorMock.Object, loggerMock.Object);
            await bus.ExecuteAsync(command).ConfigureAwait(false);

            mediatorMock.Verify(m => m.Send(command, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
